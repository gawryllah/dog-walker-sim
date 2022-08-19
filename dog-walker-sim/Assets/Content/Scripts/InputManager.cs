using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;

    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        playerControls = new PlayerControls();


        DontDestroyOnLoad(instance);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }


    public Vector2 GetPlayerMovement()
    {
        return playerControls.PlayerDefault.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.PlayerDefault.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return playerControls.PlayerDefault.Jump.triggered;
    }

    public bool GetPlayerInteracted()
    {
        return playerControls.PlayerDefault.Interact.triggered;
    }

    public bool GetPlayerLogClicked()
    {
        return playerControls.PlayerDefault.Log.triggered;
    }


}


