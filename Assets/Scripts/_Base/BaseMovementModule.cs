using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovementModule : MonoBehaviour // TODO: Get rid of this class and use an interface instead
{
    public virtual bool IsGrounded { get; private set; }
    public virtual void Initialize(Player player) { }
    public virtual void Move(Vector2 movementVector) { }
    public virtual void Jump() { }
    public virtual void Crouch() { }
    public virtual float GetCurrentVelocity() { return 0; }
}