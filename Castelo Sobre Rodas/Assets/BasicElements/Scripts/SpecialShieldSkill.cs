using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "RPG/Special Skills/Shield Skill")]
public class SpecialShieldSkill : DATA_SpecialSkillBase
{
    [Header("Escudo - Só enquanto segura")]
    public float moveSpeedMultiplier = 0.5f;
    public bool makeInvincible = true;

    public float savedMoveSpeed; // público para a habilidade acessar facilmente

    public override void OnPerformed(PlayableCharacter character, InputAction.CallbackContext context)
    {
        // 1. Salva a velocidade atual (antes de mudar)
        savedMoveSpeed = character.moveSpeed;

        // 2. Aplica o efeito
        character.moveSpeed *= moveSpeedMultiplier;
        if (makeInvincible)
            character.isInvincible = true;
    }

    public override void OnCanceled(PlayableCharacter character, InputAction.CallbackContext context)
    {
        // 3. Volta exatamente ao valor salvo
        character.moveSpeed = savedMoveSpeed;
        character.isInvincible = false;
    }
}