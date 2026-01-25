using System.Collections.Generic;
using UnityEngine;

public class Aleatorizador
{
    //ALEATORIZAR INIMIGOS

    public int resultado = 0;
    public static void SortearInimigo(List<Inimigo_DATA> inimigos)
    {
        if (inimigos == null || inimigos.Count == 0)
        {
            Debug.LogWarning("Lista de inimigos vazia!");
            return;
        }
        int Numero_de_Inimigos = inimigos.Count;
        int index = UnityEngine.Random.Range(0, Numero_de_Inimigos);

        float somaPesos = 0;
        // CRIA UMA LISTA DE PESOS QUE SAO BASEADOS NO NIVEL DE DESAFIO.
        List<float> pesos = new List<float>();
        foreach (var inimigo in inimigos)
        {
            float peso = 1f / Mathf.Max(1, inimigo.Nivel_de_Desafio);
            pesos.Add(peso);
            somaPesos += peso;
        }

        // Sorteio ponderado
        float valorSorteado = Random.Range(0f, somaPesos);
        float acumulado = 0f;

        for (int i = 0; i < inimigos.Count; i++)
        {
            acumulado += pesos[i];
            if (valorSorteado <= acumulado)
            {
                Debug.Log("Inimigo: " + inimigos[i].name);
                return;
            }
        }

        

        return;

    }
}
