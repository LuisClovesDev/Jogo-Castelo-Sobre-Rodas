using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsável pela lógica de geração e preparação das HORDAS.
///
/// Funções principais:
/// • Validar dados
/// • Planejar as hordas
/// • Gerar inimigos
/// • Inicializar sistema de controle
/// </summary>
public class HordeFunctions : MonoBehaviour
{
    // ======================================================
    // REFERÊNCIAS GERAIS
    // ======================================================

    public HordeManager HordeManager; // Referência opcional
    public int CurrentHordeIndex;     // Índice da horda atual

    // ======================================================
    // VALIDAÇÃO DAS HORDAS
    // ======================================================

    /// <summary>
    /// Valida se há hordas suficientes para iniciar o sistema.
    /// </summary>
    public static List<Hordes_Object> ValidateHordes(HordeManager manager, int minimumHordes)
    {
        List<Hordes_Object> hordes = manager.HordeList;

        int totalHordes = hordes.Count;

        if (totalHordes < minimumHordes)
        {
            Debug.LogWarning(
                $"[HordeFunctions] Hordas insuficientes!\n" +
                $"Encontradas: {totalHordes}\n" +
                $"Mínimo necessário: {minimumHordes}"
            );

            return null;
        }

        return hordes;
    }

    // ======================================================
    // PLANEJAMENTO DAS HORDAS
    // ======================================================

    /// <summary>
    /// Gera a estrutura completa das hordas.
    /// Retorna uma lista de listas de inimigos por horda.
    /// </summary>
    public static List<List<Inimigo_DATA>> PlanHordes(List<Hordes_Object> hordes, int enemiesPerHorde)
    {
        List<List<Inimigo_DATA>> allHordes = new List<List<Inimigo_DATA>>();

        for (int i = 0; i < hordes.Count; i++)
        {
            List<Inimigo_DATA> enemiesList = new List<Inimigo_DATA>();

            for (int j = 0; j < enemiesPerHorde; j++)
            {
                var enemy = Randomizer.DrawEnemy(hordes[i].list_of_creatures);

                if (enemy != null)
                {
                    enemiesList.Add(enemy);

                    // Debug opcional
                    // Debug.Log($"[PlanHordes] Horda {i} - Inimigo: {enemy.Nome_do_Inimigo}");
                }
            }

            allHordes.Add(enemiesList);
        }

        return allHordes;
    }

    // ======================================================
    // GERAÇÃO DE INIMIGOS (PRÉ-SPAWN)
    // ======================================================

    /// <summary>
    /// Instancia os inimigos da horda atual (desativados).
    /// </summary>
    public static List<GenerateHordesClass> GenerateEnemies(
     List<Hordes_Object> hordes,
     int enemiesPerHorde)
    {
        List<GenerateHordesClass> generatedHordes =
     new List<GenerateHordesClass>();

        var plannedHordes =
    PlanHordes(hordes, enemiesPerHorde);

        for (int h = 0; h < plannedHordes.Count; h++)
        {
            GenerateHordesClass generatedHorde =
              new GenerateHordesClass();

            generatedHorde.HordeIndex = h;
            var currentEnemyList =
             plannedHordes[h];

            for (int i = 0; i < currentEnemyList.Count; i++)
            {
                var enemyData = currentEnemyList[i];

                GameObject enemy =
                    GameObject.Instantiate(enemyData.prefab);

                enemy.SetActive(false);

                generatedHorde.Enemies.Add(enemy);
            }
            generatedHordes.Add(generatedHorde);
            
        }
        return generatedHordes;

    }

    // ======================================================
    // INICIALIZAÇÃO DO CONTROLE DE HORDAS
    // ======================================================

    /// <summary>
    /// Ativa o sistema responsável por controlar o ciclo das hordas.
    /// </summary>
    public static void StartHordeController(Transform parent)
    {
        Transform controller = parent.Find("Nuvem_Admin");

        if (controller != null)
        {
            controller.gameObject.SetActive(true);
            Debug.Log("[Nuvem_Admin] Sistema ativado.");
        }
        else
        {
            Debug.LogWarning("[Nuvem_Admin] Objeto não encontrado!");
        }
    }
}


// ======================================================
// GENERATED HORDES CLASS
// ======================================================
//
// Responsabilidade:
//
// • Armazenar todos os GameObjects pertencentes a uma horda.
// • Servir como estrutura para o HordeController.
//
// Futuramente poderá armazenar:
//
// • Estado da horda
// • Tempo restante
// • Quantidade de inimigos vivos
// • Dados estatísticos
//
// ======================================================

[System.Serializable]
public class GenerateHordesClass
{
    //========================================#
    // HORDE DATA
    //========================================#

    public int HordeIndex;

    //========================================#
    // ENEMIES
    //========================================#

    public List<GameObject> Enemies =
        new List<GameObject>();

    //========================================#
    // COUNT
    //========================================#

    public int EnemyCount
    {
        get
        {
            return Enemies.Count;
        }
    }
}