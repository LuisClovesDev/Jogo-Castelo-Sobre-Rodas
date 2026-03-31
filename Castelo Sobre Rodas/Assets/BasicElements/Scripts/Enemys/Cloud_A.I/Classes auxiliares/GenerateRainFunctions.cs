using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsavel por todas as funcoes de geracao de "chuvas" (ondas de inimigos).
/// Atua como o motor de processamento da CloudAI.
///
/// Funcoes principais:
/// - Validar dados coletados
/// - Gerar a estrutura do "dia"
/// - Criar os inimigos por onda
/// </summary>
public class GenerateRainFunctions : MonoBehaviour
{
    // ======================================================
    // REFERENCIAS GERAIS
    // ======================================================

    public CloudAI ClaudAI;     // Referencia opcional para a CloudAI
    public int CurrentRain;     // Indice da chuva atual

    // ======================================================
    // VALIDACAO DAS CHUVAS
    // ======================================================

    /// <summary>
    /// Valida se a quantidade de chuvas coletadas atende ao minimo necessario.
    /// </summary>
    public static List<Rains_Object> ValidateClouds(CloudAI cloudAI, int minimumRainfall)
    {
        // Coleta a lista de chuvas
        List<Rains_Object> clouds = cloudAI.Cloud_List;

        int quantidade_de_chuvas = cloudAI.Cloud_List.Count;

        // Verifica se atende ao minimo necessario
        if (quantidade_de_chuvas < minimumRainfall)
        {
            /*
            Debug.Log(
                "Quantidade de chuvas abaixo do minimo\n" +
                "Chuvas coletadas: " + quantidade_de_chuvas + "\n" +
                "Chuvas necessarias: " + minimumRainfall
            );
            */

            // Retorna null propositalmente para indicar erro
            return null;
        }
        else
        {
            return clouds;
        }
    }

    // ======================================================
    // GERACAO DO DIA (ESTRUTURA DAS ONDAS)
    // ======================================================

    /// <summary>
    /// Gera todas as listas de inimigos para cada chuva (onda).
    /// Estrutura:
    /// List<List<Inimigo_DATA>>
    /// </summary>
    public static List<List<Inimigo_DATA>> GenerateDay(List<Rains_Object> clouds, int minimumRainfall)
    {
        // Lista final contendo todas as chuvas e seus inimigos
        List<List<Inimigo_DATA>> allCloudsEnemies = new List<List<Inimigo_DATA>>();

        // Percorre cada chuva
        for (int i = 0; i < clouds.Count; i++)
        {
            // Nova lista de inimigos para essa chuva
            List<Inimigo_DATA> newEnemiesList = new List<Inimigo_DATA>();

            // Define quantidade de inimigos
            for (int j = 0; j < minimumRainfall; j++)
            {
                // Sorteia um inimigo
                var enemy = Randomizer.DrawEnemy(clouds[i].Creature);

                if (enemy != null)
                {
                    newEnemiesList.Add(enemy);

                    Debug.Log("[GenerateDay] Nuvem " + i + " - Inimigo: " + enemy.Nome_do_Inimigo);
                }
            }

            // Adiciona lista da chuva na lista principal
            allCloudsEnemies.Add(newEnemiesList);
        }

        return allCloudsEnemies;
    }

    // ======================================================
    // GERACAO DE INIMIGOS (SPAWN)
    // ======================================================

    /// <summary>
    /// Instancia os inimigos da chuva atual.
    /// </summary>
    public static void GenerateRainForWave(List<Rains_Object> clouds, int minimumRainfall)
    {
        int Current_Cloud = 0;

        // Seleciona a chuva atual
        var cloud = clouds[Current_Cloud];

        // Gera todas as listas de inimigos
        var enemies = GenerateDay(clouds, minimumRainfall);

        // Pega apenas a lista da chuva atual
        var Current_Enemy_List = enemies[Current_Cloud];

        Debug.Log("[GenerateRainForWave] Quantidade de inimigos: " + Current_Enemy_List.Count);

        // Spawn dos inimigos
        for (int c = 0; c < Current_Enemy_List.Count; c++)
        {
            var inimigo_atual = Current_Enemy_List[c];

            // Instancia o prefab
            GameObject inimigo = GameObject.Instantiate(inimigo_atual.prefab);

            Debug.Log("[Spawn] Inimigo gerado: " + inimigo_atual.Nome_do_Inimigo);

            // inimigo.SetActive(false);
        }
    }
}