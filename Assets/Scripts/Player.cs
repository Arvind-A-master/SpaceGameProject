using UnityEngine;

public class Player : Entity
{
    public PlayerInputSet input { get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState MoveState { get; private set; }

    [Header("Movement details")]
    public float moveSpeed;
    public Vector2 moveInput { get; private set; }

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
    }

    private void OnDisable()
    {
        input.Disable();
    }


}
