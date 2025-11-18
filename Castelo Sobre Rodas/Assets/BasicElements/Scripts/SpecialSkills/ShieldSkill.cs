using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "RPG/Special Skills/Shield Skill")]
public class ShieldSkill : SpecialSkill
{
    [Header("Escudo - Só enquanto segura")]
    public float moveSpeedMultiplier = 0.5f;
    public bool makeInvincible = true;

    public float reducedMoveSpeed;

    public override void OnPerformed(PlayableCharacter character, InputAction.CallbackContext context)
    {
        // 1. Salva a velocidade atual (antes de mudar)
        reducedMoveSpeed = character.playerClass.baseStats.moveSpeed - (character.playerClass.baseStats.moveSpeed * moveSpeedMultiplier);

        // 2. Aplica o efeito
        character.playerClass.bonusStats.moveSpeed -= reducedMoveSpeed;
        if (makeInvincible)
            character.isInvincible = true;
    }

    public override void OnCanceled(PlayableCharacter character, InputAction.CallbackContext context)
    {
        // 3. Volta exatamente ao valor salvo
        character.playerClass.bonusStats.moveSpeed += reducedMoveSpeed;
        character.isInvincible = false;
    }
}
