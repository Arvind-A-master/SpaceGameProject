using System.Xml;
using UnityEngine;

public class StateMachine 
{
   public EntityState currentState {  get; private set; }
    
    public void Initialize(EntityState startstate)
    {
        currentState = startstate;
        currentState.Enter();

    }

    public void ChangeState(EntityState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();

    }

    public void UpdateActiveState()
    {
        currentState.Update();
    }
}
