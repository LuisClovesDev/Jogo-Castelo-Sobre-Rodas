using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsavel por realizar sorteios de inimigos.
/// Utiliza sistema de peso baseado no nivel de desafio.
///
/// Logica:
/// - Quanto maior o nivel de desafio, menor a chance de ser sorteado
/// - Quanto menor o nivel de desafio, maior a chance de aparecer
/// </summary>
public class Randomizer
{
    // ======================================================
    // SORTEIO DE INIMIGOS
    // ======================================================

    /// <summary>
    /// Sorteia um inimigo com base em peso (nivel de desafio).
    /// </summary>
    /// <param name="Enemy">Lista de inimigos disponiveis</param>
    /// <returns>Inimigo sorteado ou null</returns>
    public static Inimigo_DATA DrawEnemy(List<Inimigo_DATA> Enemy)
    {
        // Lista auxiliar (nao utilizada diretamente, mantida conforme estrutura original)
        List<Inimigo_DATA> New_Enemys_List = new List<Inimigo_DATA>();

        // --------------------------------------------------
        // VALIDACAO DA LISTA
        // --------------------------------------------------

        if (Enemy == null || Enemy.Count == 0)
        {
            Debug.LogWarning("Lista de inimigos vazia!");
            return null;
        }

        int EnemiesNumber = Enemy.Count;

        // Indice aleatorio simples (nao utilizado no retorno final, mantido)
        int index = UnityEngine.Random.Range(0, EnemiesNumber);

        // --------------------------------------------------
        // CALCULO DOS PESOS
        // --------------------------------------------------

        float sumWeights = 0f; // Soma total dos pesos

        // Lista de pesos baseada no nivel de desafio
        List<float> weightlist = new List<float>();

        foreach (var inimigo in Enemy)
        {
            // Peso inversamente proporcional ao nivel de desafio
            float Weight = 1f / Mathf.Max(1f, inimigo.Nivel_de_Desafio);

            weightlist.Add(Weight);
            sumWeights += Weight;
        }

        // --------------------------------------------------
        // SORTEIO PONDERADO
        // --------------------------------------------------

        // Valor aleatorio dentro do intervalo total de pesos
        float valueDrawn = Random.Range(0f, sumWeights);

        float accumulated = 0f; // Acumulador de pesos

        for (int i = 0; i < Enemy.Count; i++)
        {
            accumulated += weightlist[i];

            // Quando o valor sorteado cair dentro do intervalo acumulado
            if (valueDrawn <= accumulated)
            {
                // Debug.Log("Inimigo criado: " + Enemy[i]);
                return Enemy[i];
            }
        }

        // Caso nenhum inimigo seja selecionado (fallback)
        return null;
    }
}