using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    public PlayerInputSet input { get; private set; }
    public Player_IdleState idleState { get; private set; }
    public Player_MoveState MoveState { get; private set; }
 



    [Header("Movement details")]
    public float moveSpeed;
    public Vector2 moveInput { get; private set; }

    [Header("Shooting")]
    public GameObject ShootEffect;
    public float blastRadius = 2f;
    public LayerMask enemyLayers;

    protected override void Awake()
    {
        base.Awake();
        input = new PlayerInputSet();
        idleState = new Player_IdleState(this, stateMachine, "idle");       
        MoveState = new Player_MoveState(this, stateMachine, "Move");
    
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }
    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += ctx => {
            Vector2 rawInput = ctx.ReadValue<Vector2>();            
            if (rawInput.magnitude > 1f)
                rawInput = rawInput.normalized;
            moveInput = rawInput;
        };
        input.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

        input.Player.Shoot.performed += HandleShoot;


    }

       

    private void OnDisable()
    {
        input.Disable();
    }
    private void HandleShoot(InputAction.CallbackContext context)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPosition.z = 0f;
        if (ShootEffect != null)
        {
            GameObject effect = Instantiate(ShootEffect, mouseWorldPosition, Quaternion.identity);
            Destroy(effect, 0.2f);
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0f;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mouseWorldPos, blastRadius);
    }

}
