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

    //private bool isLogOpened;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;


    }

    void Update()
    {
        Move();
        Interactions();
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
            Debug.Log("Interacted");
        }
    }

    void LogHandler()
    {
        if (inputManager.GetPlayerLogClicked())
        {
            if (!UIManager.Instance.LogOpened)
            {
                GameManager.Instance.OpenLog();
            }
            else
            {
                GameManager.Instance.CloseLog();
            }
        }
    }






}
