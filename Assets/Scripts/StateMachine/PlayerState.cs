using UnityEngine;

public abstract class PlayerState : EntityState
{
    protected Player player;
    protected PlayerInputSet input;
    public PlayerState(Player player,StateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        this.player = player;
        anim = player.anim;
        input = player.input;

    }

    public override void Update()
    {
        base.Update();

    }
}

