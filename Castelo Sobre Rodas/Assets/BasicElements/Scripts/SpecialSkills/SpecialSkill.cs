using UnityEngine;
using UnityEngine.InputSystem;

// Classe base abstrata, NÃO é instanciável
public abstract class SpecialSkill : ScriptableObject
{
    public string displayName;
    public float cooldown;
    public Sprite icon;

    public abstract void OnPerformed(PlayableCharacter character, InputAction.CallbackContext context);
    public abstract void OnCanceled(PlayableCharacter character, InputAction.CallbackContext context);
}
