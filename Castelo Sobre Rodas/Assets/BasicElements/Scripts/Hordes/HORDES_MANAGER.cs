using System.Collections.Generic;
using UnityEngine;

// ==========================================================
// SISTEMA DE HORDAS
// ==========================================================
//
// RESPONSABILIDADE:
// Gerenciar completamente a geração, execução e controle das hordas de inimigos.
//
// ==========================================================
// PART 01 - COLETA DE DADOS
// ==========================================================
//
// O sistema coleta:
//
// • Jogador
// • Hordas disponíveis
// • Informações do cenário
// • Referências importantes do jogo
//
// ==========================================================
// PART 02 - PLANEJAMENTO DAS HORDAS
// ==========================================================
//
// Define como será o ciclo de hordas:
//
// • Quantidade de hordas
// • Intensidade de cada horda
// • Tipos de inimigos
// • Quantidade de cada tipo
//
// Regras:
//
// • Baseado em estatísticas + aleatoriedade controlada
// • Respeita limites de inimigos e tipos disponíveis
//
// Exemplo:
//
// HORDA 1 → 5 inimigos tipo A
// HORDA 2 → 10 inimigos tipo A
//
// Resultado:
// → Serão criados 10 inimigos tipo A (maior necessidade)
//
// • Todos os inimigos são pré-gerados e DESATIVADOS
// • Serão ativados apenas quando a horda iniciar
//
// ==========================================================
// PART 03 - EXECUÇÃO DAS HORDAS
// ==========================================================
//
// O sistema:
//
// • Sabe qual é a horda atual
// • Ativa os inimigos daquela horda
// • Controla o tempo de duração
//
// IMPORTANTE:
// Os inimigos da horda já devem estar previamente criados.
//
// ==========================================================
// PART 04 - CONTROLE E CICLO
// ==========================================================
//
// O sistema gerencia:
//
// • Início e fim das hordas
// • Ativação e desativação de inimigos
// • Tempo entre hordas
// • Possível reutilização de inimigos
// • Spawn de itens e eventos
//
// ==========================================================

public class HordeManager : MonoBehaviour
{
    // ======================================================
    // LOCALIZAÇÃO DO JOGADOR
    // ======================================================

    [Header("Player Settings")]

    public string playerTag = "Player";
    public GameObject player;

    /// <summary>
    /// Localiza o jogador pela tag.
    /// </summary>
    void FindPlayer()
    {
        if (ObjectLocator.findtag(playerTag, out player))
        {
            Debug.Log($"[HordeManager] Jogador encontrado: {player.name}", player);
        }
    }

    // ======================================================
    // LISTA DE HORDAS
    // ======================================================

    [Header("Horde Settings")]

    public List<Hordes_Object> HordeList = new List<Hordes_Object>();

    /// <summary>
    /// Localiza todas as hordas disponíveis.
    /// </summary>
    List<Hordes_Object> FindHordes()
    {
        HordeList = ObjectLocator.Find_All_Hordes();

        if (HordeList != null)
        {
            return HordeList;
        }

        return null;
    }

    // ======================================================
    // GERAÇÃO DAS HORDAS
    // ======================================================

    [Header("Generation Settings")]

    public int minimumHordes = 10;

    public List<GenerateHordesClass> GeneratedHordes =
    new List<GenerateHordesClass>();

    /// <summary>
    /// Gera toda a estrutura das hordas:
    /// • Validação
    /// • Planejamento
    /// • Criação de inimigos
    /// </summary>
    public void GenerateHordes()
    {
        // 1. Valida dados
        HordeFunctions.ValidateHordes(this, minimumHordes);

        // 2. Planeja as hordas do jogo
       // HordeFunctions.PlanHordes(HordeList, minimumHordes);

        // 3. Cria inimigos (desativados)
        GeneratedHordes =
     HordeFunctions.GenerateEnemies(
         HordeList,
         minimumHordes);

        // 4. Inicia o sistema de controle das hordas
        Invoke(nameof(StartHordeControl), 5f);
    }

    void StartHordeControl()
    {
        HordeFunctions.StartHordeController(this.transform);
    }

    // ======================================================
    // CICLO DE VIDA
    // ======================================================

    private void Awake()
    {
        FindPlayer();
        FindHordes();
        GenerateHordes();
    }
}