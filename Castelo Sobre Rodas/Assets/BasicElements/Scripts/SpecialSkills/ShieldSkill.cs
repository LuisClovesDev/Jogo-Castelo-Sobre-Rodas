using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "RPG/Special Skills/Shield Skill")]
public class ShieldSkill : SpecialSkill
{
    [Header("Escudo - Só enquanto segura")]
    public float moveSpeedMultiplier = 0.5f;
    public bool makeInvincible = true;

    public float savedMoveSpeed;

    public override void OnPerformed(PlayableCharacter character, InputAction.CallbackContext context)
    {
        // 1. Salva a velocidade atual (antes de mudar)
        savedMoveSpeed = character.playerClass.baseStats.moveSpeed;

        // 2. Aplica o efeito
        character.playerClass.bonusStats.moveSpeed = character.playerClass.baseStats.moveSpeed * moveSpeedMultiplier;
        if (makeInvincible)
            character.isInvincible = true;
    }

    public override void OnCanceled(PlayableCharacter character, InputAction.CallbackContext context)
    {
        // 3. Volta exatamente ao valor salvo
        character.playerClass.baseStats.moveSpeed = savedMoveSpeed;
        character.isInvincible = false;
    }
}
