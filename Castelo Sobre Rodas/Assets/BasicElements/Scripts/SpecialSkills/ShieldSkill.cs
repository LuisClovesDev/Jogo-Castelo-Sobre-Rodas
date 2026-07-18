using UnityEngine;

[CreateAssetMenu(menuName = "RPG/Special Skills/Shield Skill")]
public class ShieldSkill : SpecialSkill
{
    public float MoveSppedAsaClick = 0;
    public bool makeInvincible = true;

    public override void OnPerformed(PlayableCharacter character)
    {
        Debug.Log("Botão Precionado");
        
       character.playerClass.bonusStats.moveSpeed = MoveSppedAsaClick;

        if (makeInvincible)
            character.isInvincible = true;
        
    }

    public override void OnCanceled(PlayableCharacter character)
    {
        Debug.Log("Botão Precionado");
        
        character.playerClass.bonusStats.moveSpeed = 0f;
        character.isInvincible = false;
        
    }
}