using UnityEngine;

public class Player_MoveState : PlayerState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();
        if (player.moveInput.x == 0 && player.moveInput.y == 0)
            stateMachine.ChangeState(player.idleState);

        else if (player.moveInput.x != 0 && player.moveInput.y == 0)
            player.SetVelocity(player.moveInput.x * player.moveSpeed, 0);

        else if (player.moveInput.x == 0 && player.moveInput.y != 0)
            player.SetVelocity(0, player.moveInput.y * player.moveSpeed);

        else
            player.SetVelocity(player.moveInput.x * player.moveSpeed, player.moveInput.y * player.moveSpeed);
    }

}
