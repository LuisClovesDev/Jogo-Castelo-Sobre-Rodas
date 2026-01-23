using UnityEngine;

[CreateAssetMenu(menuName = "RPG/Special Skills/Shield Skill")]
public class ShieldSkill : SpecialSkill
{
    public float moveSpeedMultiplier = 0.5f;
    public bool makeInvincible = true;

    public override void OnPerformed(PlayableCharacter character)
    {
        character.playerClass.bonusStats.moveSpeed =
            character.playerClass.baseStats.moveSpeed * moveSpeedMultiplier;

        if (makeInvincible)
            character.isInvincible = true;
    }

    public override void OnCanceled(PlayableCharacter character)
    {
        character.playerClass.bonusStats.moveSpeed = 0f;
        character.isInvincible = false;
    }
}