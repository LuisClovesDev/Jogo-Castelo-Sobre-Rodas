using UnityEngine;
using UnityEngine.InputSystem;

public class Soldado : PlayableCharacter
{
    public Classe_DATA Soldado_reference;


    protected override void OnStart()
    {
        if (Soldado_reference != null)
        {
            moveSpeed = Soldado_reference.TotalMoveSpeed;
        }
        else
        {
            Debug.LogWarning("Referência a Classe_DATA não atribuída.");
        }
    }

    public override void RightClickAction(InputAction.CallbackContext context)
    {
        if (Soldado_reference?.activeSkill != null)
        {
            if (context.performed)
            {
                Soldado_reference.activeSkill.OnPerformed(this, context);
            }
            else if (context.canceled)
            {
                Soldado_reference.activeSkill.OnCanceled(this, context);
            }
        }
    }
}