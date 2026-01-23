using UnityEngine;

[System.Serializable]
public struct PlayerStats
{
    public float maxHealth;           // Vida
    public float currentHealth;       // Vida atual
    public float attack;              // Dano
    public float attackSpeed;         // Velocidade de ataque
    public float moveSpeed;           // Velocidade de movimento
    public float range;               // Alcance
    public float specialRecharge;     // Tempo de recarga da skill

    public PlayerStats(
        float maxHealth,
        float currentHealth,
        float attack,
        float attackSpeed,
        float moveSpeed,
        float range,
        float specialRecharge)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.attack = attack;
        this.attackSpeed = attackSpeed;
        this.moveSpeed = moveSpeed;
        this.range = range;
        this.specialRecharge = specialRecharge;
    }

    // IMPORTANTE: Struct → Reset() só funciona se chamado no objeto real
    public void Reset()
    {
        maxHealth = 0;
        currentHealth = 0;
        attack = 0;
        attackSpeed = 0;
        moveSpeed = 0;
        range = 0;
        specialRecharge = 0;
    }
}

