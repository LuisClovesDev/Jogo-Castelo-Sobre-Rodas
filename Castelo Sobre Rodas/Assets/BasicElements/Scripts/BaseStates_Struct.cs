using UnityEngine;

[System.Serializable]
public struct BaseStats
{
    public float hp;                  // Vida base
    public float attack;              // Dano base
    public float attackSpeed;         // Velocidade de ataque base
    public float moveSpeed;           // Velocidade de movimento base
    public float range;               // Alcance base
    public float specialRecharge;     // Tempo base de recarga da skill

    public BaseStats(
        float hp,
        float attack,
        float attackSpeed,
        float moveSpeed,
        float range,
        float specialRecharge)
    {
        this.hp = hp;
        this.attack = attack;
        this.attackSpeed = attackSpeed;
        this.moveSpeed = moveSpeed;
        this.range = range;
        this.specialRecharge = specialRecharge;
    }
}

