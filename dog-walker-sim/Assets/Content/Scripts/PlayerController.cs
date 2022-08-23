using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public PlayerControlsSO playerControls;

    private CharacterController controller;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private InputManager inputManager;

    private GameObject lasthit; public GameObject RayCastInfo { get { return lasthit; } }

    //private bool isLogOpened;

    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float rayLength = 2.5f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        Move();
        Interactions();
        if (ray.origin != null)
            Debug.DrawLine(ray.origin, ray.direction * rayLength);
    }

    void Move()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0;

        controller.Move(move * Time.deltaTime * playerControls.PlayerSpeed);

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(playerControls.JumpHeight * -3.0f * playerControls.GravityValue);
        }

        playerVelocity.y += playerControls.GravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Interactions()
    {
        Interact();
        LogHandler();

    }

    void Interact()
    {



        if (groundedPlayer && inputManager.GetPlayerInteracted())
        {
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));



            if (Physics.Raycast(ray, out hit, rayLength, interactableLayer))
            {
                lasthit = hit.transform.gameObject;

                switch (lasthit.tag)
                {
                    case "TaskDestination":

                        if (lasthit.GetComponent<TaskDestination>() != null)
                        {
                            lasthit.GetComponent<TaskDestination>().Interact();
                        }
                        break;
                }
            }


            Debug.DrawLine(ray.origin, hit.point, Color.red);

        }



    }



    void LogHandler()
    {
        if (inputManager.GetPlayerLogClicked())
        {
            if (UIManager.Instance.LogOpen)
            {
                GameManager.Instance.CloseLog();
            }
            else
            {
                GameManager.Instance.OpenLog();
            }
        }
        ToggleCursorLock();
    }

    void ToggleCursorLock()
    {
        if (UIManager.Instance.LogOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }






}
