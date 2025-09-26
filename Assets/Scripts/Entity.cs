using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator anim {  get; private set; }
    public Rigidbody2D rb { get; private set; }
    protected StateMachine stateMachine;


    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine = new StateMachine();
    }

    protected virtual void Start()
    {

    }
    public virtual void Update()
    {
        stateMachine.UpdateActiveState();
    }
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
       
    }
}
