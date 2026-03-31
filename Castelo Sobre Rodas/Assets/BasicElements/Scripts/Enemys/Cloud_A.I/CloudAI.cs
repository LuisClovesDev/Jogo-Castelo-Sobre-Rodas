using System.Collections.Generic;
using UnityEngine;

// ☁️ ☁️ CLOUD I.A ☁️ ☁️
//
// CONCEITO GERAL:
// Responsável pela gestão completa dos inimigos e do nível de desafio.
// A lógica é baseada em uma analogia climática:
//
// - Nuvem   = Sistema de controle (IA)
// - Chuva   = Ondas de inimigos
// - Clima   = Dificuldade / comportamento do dia
//
// ==========================================================
// PART 01 - COLETA DE DADOS
// ==========================================================
// A nuvem coleta e armazena informações antes de iniciar:
//
// • Jogador
// • Chuvas (ondas disponíveis)
// • Cenário atual
// • Castelo
//
// ==========================================================
// PART 02 - PLANEJAMENTO DO DIA
// ==========================================================
// A nuvem define como será o "dia":
//
// • Quantidade de ondas
// • Intensidade de cada onda
// • Tipos de inimigos
// • Quantidade por tipo
//
// Regras:
//
// • A geração é baseada em estatísticas + aleatoriedade controlada
// • Respeita limite de inimigos e tipos disponíveis
//
// Exemplo:
//
// CHUVA 1 → 5 inimigos tipo A
// CHUVA 2 → 10 inimigos tipo A
//
// Resultado:
// → Serão criados 10 inimigos tipo A (maior necessidade)
//
// • Todos os inimigos são pré-gerados e DESATIVADOS
// • Serão ativados apenas quando a onda iniciar
//
// ==========================================================
// PART 03 - EXECUÇÃO
// ==========================================================
//
// Após definir:
//
// • Como é o dia
// • Como serão as chuvas
// • Qual a chuva atual
//
// A nuvem:
//
// • Ativa e desativa inimigos conforme necessário
//
// IMPORTANTE:
// Os inimigos da onda atual já devem estar previamente criados.
//

public class CloudAI : MonoBehaviour
{
    // ======================================================
    // PART 01 - LOCALIZAÇÃO DO JOGADOR
    // ======================================================

    [Header("Player Settings")]

    public string playerTag = "Player";   // Nome da tag usada para identificar o jogador
    public GameObject player;             // Referência ao objeto do jogador encontrado

    /// <summary>
    /// Localiza o jogador com base na tag definida.
    /// Caso encontre, armazena a referência e exibe no log.
    /// </summary>
    void Findplayer()
    {
        // Tenta localizar o jogador via ObjectLocator
        if (ObjectLocator.findtag(playerTag, out player))
        {
            Debug.Log($"[LocalizarJogador] Jogador encontrado: {player.name}", player);
        }
        // Caso não encontre, o método interno já deve tratar/logar
    }

    // ======================================================
    // PART 01 - COLETA DAS CHUVAS (ONDAS)
    // ======================================================

    [Header("Cloud / Rain Settings")]

    public List<Rains_Object> Cloud_List = new List<Rains_Object>();
    // Lista contendo todas as chuvas (ondas) disponíveis

    /// <summary>
    /// Localiza todas as chuvas disponíveis no sistema.
    /// Busca geralmente dentro de: Assets > Resources > Chuvas
    /// </summary>
    /// <returns>Lista de chuvas encontradas ou null</returns>
    List<Rains_Object> FindClouds()
    {
        // Localiza todas as chuvas usando o ObjectLocator
        Cloud_List = ObjectLocator.LocalizarTodosOsChuvas();

        // Converte nomes para debug (opcional)
        string names = string.Join(", ", Cloud_List.ConvertAll(c => c.name));

        //Debug.Log($"[LocalizarChuvas] Chuvas encontradas: {Cloud_List.Count} | {names}");

        if (Cloud_List != null)
        {
            return Cloud_List;
        }
        else
        {
            return null;
        }
    }

    // ======================================================
    // PART 02 - DEFINIÇÃO DO DIA (RUN)
    // ======================================================

    [Header("Generation Settings")]

    // Quantidade mínima de "chuvas" (ondas) por dia
    public int MinimumRainfall = 10;

    /// <summary>
    /// Gera toda a estrutura do dia:
    /// • Valida dados
    /// • Define o comportamento das chuvas
    /// • Gera inimigos (pré-instanciados e desativados)
    /// </summary>
    public void GenerateRain()
    {
        // 1. Valida se as chuvas estão corretas e dentro dos padrões
        GenerateRainFunctions.ValidateClouds(this, MinimumRainfall);

        // 2. Define como será o dia (distribuição das chuvas)
        GenerateRainFunctions.GenerateDay(Cloud_List, MinimumRainfall);

        // 3. Gera os inimigos de cada onda (inicialmente desativados)
        GenerateRainFunctions.GenerateRainForWave(Cloud_List, MinimumRainfall);
    }

    // ======================================================
    // CICLO DE VIDA
    // ======================================================

    private void Awake()
    {
        // 1. Localiza o jogador
        Findplayer();

        // 2. Localiza as chuvas disponíveis
        FindClouds();

        // 3. Gera o dia e estrutura das ondas
        GenerateRain();
    }
}