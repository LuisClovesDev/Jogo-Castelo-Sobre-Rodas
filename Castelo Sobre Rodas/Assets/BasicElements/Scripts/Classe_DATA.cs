using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Classe_DATA", menuName = "Scriptable Objects/Classe_DATA")]
public class Classe_DATA : ScriptableObject
{
    [Header("Identidade da Classe")]
    public string className;

    [Header("Status Base")]
    public BaseStats baseStats;

    [Header("Bônus")]
    public BonusStats bonusStats;

    [Header("Habilidade Especial")]
    public DATA_SpecialSkillBase activeSkill; // ← aceita qualquer habilidade

    // Propriedades úteis
    public float TotalMoveSpeed => baseStats.moveSpeed + bonusStats.bonusMoveSpeed;
    public float TotalAttack => baseStats.attack + bonusStats.bonusAttack;
    // ... outras propriedades conforme necessário
}