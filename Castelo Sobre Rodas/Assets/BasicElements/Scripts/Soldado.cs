using UnityEngine;
using UnityEngine.InputSystem;

public class Soldier : PlayableCharacter
{
	
	public override void RightClickAction(InputAction.CallbackContext context)
	{
		if (context.canceled)
		{
			moveSpeed = moveSpeed * 2;
		}
		else if (context.performed)
		{
			moveSpeed = moveSpeed / 2;
		}
	}

}
