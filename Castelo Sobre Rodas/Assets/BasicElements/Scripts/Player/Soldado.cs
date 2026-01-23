using UnityEngine;
using UnityEngine.InputSystem;

public class Soldier : PlayableCharacter
{
    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        ApplyMovement(direction);
    }

    public void OnLeftClick(InputValue value)
    {
        LeftClickAction(value.isPressed);
    }

    public void OnRightClick(InputValue value)
    {
        RightClickAction(value.isPressed);
    }
}
