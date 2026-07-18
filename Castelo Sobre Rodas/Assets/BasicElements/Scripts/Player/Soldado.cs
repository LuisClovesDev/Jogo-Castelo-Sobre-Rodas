using UnityEngine;
using UnityEngine.InputSystem;

public class Soldier : PlayableCharacter
{
    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        ApplyMovement(direction);
    }

    private void Update()
    {
        if(Mouse.current.rightButton.wasPressedThisFrame)
    {
            Debug.Log("PRESSIONOU");
            RightClickAction(true);
        }

        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            Debug.Log("SOLTOU");
            RightClickAction(false);
        }
    }

    
}

    /*
    public void OnLeftClick(InputValue value)
    {
        
        LeftClickAction(value.isPressed);
    }

    public void OnRightClickAction(InputValue value)
    {
        Debug.Log("Método chamado");

        Debug.Log("isPressed = " + value.isPressed);
    }
    */

