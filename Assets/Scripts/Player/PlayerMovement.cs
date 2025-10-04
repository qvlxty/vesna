using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    public float movementSpeed = 20f;
    
    [SerializeField]
    public CharacterController characterController;
    
    void Start()
    {
        this.playerInput = GetComponent<PlayerInput>();
    } 

    void Update()
    {
        var playerMov = this.playerInput.actions["Move"].ReadValue<Vector2>();
        this.characterController.Move(new Vector3(
            playerMov.x,
            0,
            playerMov.y
        ) * (Time.deltaTime * movementSpeed));
    }
    
}
