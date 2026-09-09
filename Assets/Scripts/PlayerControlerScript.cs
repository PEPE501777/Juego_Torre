using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 0.000000001f;

    [Header("Jump")]
    public float jumpHeight = 0.002f;

    [Header("Gravity")]
    public float gravity = -9.81f;

    [SerializeField] private Camera arCamera;
    [SerializeField] private GameObject planeFinder;

    private bool detenido;
    private bool colocado;
    private float aceptarToqueDesde;


    private CharacterController controller;
    private PlayerControls controls;

    private Vector2 moveInput;
    private Vector3 velocity;

    private bool active = false;

    public void Awake()
    {
        controller = GetComponent<CharacterController>();

        controls = new PlayerControls();

        controls.Player.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
        };

        controls.Player.Move.canceled += ctx =>
        {
            moveInput = Vector2.zero;
        };

        controls.Player.Jump.performed += ctx =>
        {
            Jump();
        };
    }

    public void ActivarInteraccion(GameObject contenidoColocado)
    {
        colocado = true;

        aceptarToqueDesde = Time.unscaledTime + 0.3f;

        if (planeFinder != null)
            planeFinder.SetActive(false);
    }



    private void OnEnable()
    {
        controls.Enable();
 
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        Move();
        ApplyGravity();
        Debug.Log("Move Input: " + moveInput);
    }

    private void Move()
    {

        Vector3 movement = new Vector3(moveInput.x,0f,moveInput.y);

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}