using UnityEngine;
using UnityEngine.InputSystem;

public class Soldier : PlayableCharacter
{

	public void OnPrimaryInput(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			var tapPoint = context.ReadValue<Vector2>();
			Debug.Log(tapPoint);
		}
	}

}
