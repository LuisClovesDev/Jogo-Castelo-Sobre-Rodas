using System.Collections.Generic;
using UnityEngine;

public class Randomizer
{
    //ALEATORIZAR INIMIGOS

    public int resultado = 0;
    public static void DrawEnemy(List<Inimigo_DATA> Enemy)
    {
        if (Enemy == null || Enemy.Count == 0)
        {
            Debug.LogWarning("Lista de inimigos vazia!");
            return;
        }
        int EnemiesNumber = Enemy.Count;
        int index = UnityEngine.Random.Range(0, EnemiesNumber);

        float sumWeights = 0; // <- SOMA DOS PESOS
        // CRIA UMA LISTA DE PESOS QUE SAO BASEADOS NO NIVEL DE DESAFIO.
        List<float> weightlist = new List<float>();
        foreach (var inimigo in Enemy)
        {
            float Weight = 1f / Mathf.Max(1, inimigo.Nivel_de_Desafio); // <- PESOS
            weightlist.Add(Weight);
            sumWeights += Weight;
        }

        // Sorteio ponderado
        float valueDrawn = Random.Range(0f, sumWeights);// <- VALOR DO SORTEIO
        float accumulated = 0f; // ACUMULADO DE PESOS

        for (int i = 0; i < Enemy.Count; i++)
        {
            accumulated += weightlist[i];
            if (valueDrawn <= accumulated)
            {
                Debug.Log("Inimigo: " + Enemy[i].name);
                return;
            }
        }

        

        return;

    }
}
