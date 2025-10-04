using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private CharacterController characterController;
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
        if (!IsOwner) return;
    
        _playerMov = playerInput.actions["Move"].ReadValue<Vector2>();
    
        Vector3 move = new Vector3(_playerMov.x, 0, _playerMov.y) * movementSpeed;
        characterController.Move(move * Time.deltaTime);
    
        // NetworkTransform автоматически синхронизирует позицию!
    }
    
}
