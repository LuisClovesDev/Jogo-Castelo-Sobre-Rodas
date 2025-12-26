using UnityEngine;


[CreateAssetMenu(fileName = "Inimigo_DATA", menuName = "Scriptable Objects/Inimigo_DATA")]
public class Inimigo_DATA : ScriptableObject
{
    public string enemyName;                    //NOME

    public float maxHP;                         // VIDA MAXIMO
    public float speed;                         // VELOCIDADE DE MOVIMENTO
    public float damage;                        // DANO
    public int xpValue;                         //VALOR DE XP

    public float size;

    public EnemyBehaviorType behaviorType;

}

public enum EnemyBehaviorType
{
    Mini_Arvore,
    Passaro,
    Arvore_Grande,
    Planta_Atiradora
}