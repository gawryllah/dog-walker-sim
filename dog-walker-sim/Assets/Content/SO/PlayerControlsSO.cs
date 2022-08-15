using UnityEngine;


[CreateAssetMenu(fileName = "PlayerControlsSO", menuName = "ScriptableObjects/PlayerControlsSO")]
public class PlayerControlsSO : ScriptableObject
{

    [SerializeField] private float playerSpeed = 10;
    [SerializeField] private float jumpHeight = 1.55f;
    [SerializeField] private float gravityValue = -29.08f;

    public float PlayerSpeed { get { return playerSpeed; } }
    public float JumpHeight { get { return jumpHeight; } }
    public float GravityValue { get { return gravityValue; } }

}
