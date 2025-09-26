using UnityEngine;

public class Player_IdleState : PlayerState
{
    public Player_IdleState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, 0);
    }
    public override void Update()
    {
        if(player.moveInput.x !=0 || player.moveInput.y !=0 )
            stateMachine.ChangeState(player.MoveState);
    }
}
