using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    public IState CurrentState { get; }
    public void ChangeState(IState state);
    public void Initialize();
}