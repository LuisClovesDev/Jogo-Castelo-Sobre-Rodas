using UnityEngine;


[CreateAssetMenu(fileName = "Inimigo_DATA", menuName = "Inimigos /Inimigo_DATA")]
public class Inimigo_DATA : ScriptableObject
{
    public string Nome_do_Inimigo;                     //NOME
    public int Nivel_de_Desafio;                      // NIVEL DE DIFICULDADE

    public float Vida_Maxima;                          // VIDA MAXIMO
    public float Velocidade;                          // VELOCIDADE DE MOVIMENTO
    public float Dano;                               // DANO
    public int Valor_de_XP;                         //VALOR DE XP

    public float Tamanho;
    public GameObject prefab;

    public EnemyBehaviorType behaviorType;

}

public enum EnemyBehaviorType
{
    Mini_Arvore,
    Passaro,
    Arvore_Grande,
    Planta_Atiradora
}