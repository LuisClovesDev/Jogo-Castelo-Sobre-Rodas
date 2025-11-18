using UnityEngine;

[CreateAssetMenu(fileName = "PlayerClass", menuName = "Scriptable Objects/PlayerClass")]
public class PlayerClass : ScriptableObject
{
    [Header("Identidade da Classe")]
    public string className;

    [Header("Status Base")]
    public PlayerStats baseStats;

    [Header("Bônus")]
    public PlayerStats bonusStats;

    [Header("Habilidade Especial")]
    public SpecialSkill specialSkill; // ← aceita qualquer habilidade

    // Propriedades úteis
    public float attack => baseStats.attack + bonusStats.attack;
    public float moveSpeed => baseStats.moveSpeed + bonusStats.moveSpeed;
    // ... outras propriedades conforme necessário
}
