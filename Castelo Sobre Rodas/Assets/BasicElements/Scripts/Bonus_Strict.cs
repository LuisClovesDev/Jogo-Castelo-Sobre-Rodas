using UnityEngine;

[System.Serializable]
public struct BonusStats
{
    public float bonusHP;
    public float bonusAttack;
    public float bonusAttackSpeed;
    public float bonusMoveSpeed;
    public float bonusRange;
    public float bonusSpecialRecharge;

    public BonusStats(
        float bonusHP,
        float bonusAttack,
        float bonusAttackSpeed,
        float bonusMoveSpeed,
        float bonusRange,
        float bonusSpecialRecharge)
    {
        this.bonusHP = bonusHP;
        this.bonusAttack = bonusAttack;
        this.bonusAttackSpeed = bonusAttackSpeed;
        this.bonusMoveSpeed = bonusMoveSpeed;
        this.bonusRange = bonusRange;
        this.bonusSpecialRecharge = bonusSpecialRecharge;
    }

    // IMPORTANTE: Struct → Reset() só funciona se chamado no objeto real
    public void Reset()
    {
        bonusHP = 0;
        bonusAttack = 0;
        bonusAttackSpeed = 0;
        bonusMoveSpeed = 0;
        bonusRange = 0;
        bonusSpecialRecharge = 0;
    }
}
