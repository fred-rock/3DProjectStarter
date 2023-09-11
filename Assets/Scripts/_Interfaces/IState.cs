using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public IEnumerator EntryState();

    public void UpdateState();

    public void FixedUpdateState();

    public IEnumerator ExitState(); 
}
