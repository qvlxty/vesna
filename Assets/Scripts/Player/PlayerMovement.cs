using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    private PlayerInput playerInput;
    public float movementSpeed = 20f;
    
    [SerializeField]
    public CharacterController characterController;

    public GameObject camera;

    private Vector2 _playerMov;

    void Start()
    {
        this.playerInput = GetComponent<PlayerInput>();
        if (!IsOwner)
        {
            camera.SetActive(false);
        }
    } 

    void Update()
    {
        // Можно управлять только своим игроком
        if (!IsOwner) return;
        
        _playerMov = this.playerInput.actions["Move"].ReadValue<Vector2>();
        this.characterController.Move(new Vector3(
            _playerMov.x,
            0,
            _playerMov.y
        ) * (Time.deltaTime * movementSpeed));
    }
    
}
