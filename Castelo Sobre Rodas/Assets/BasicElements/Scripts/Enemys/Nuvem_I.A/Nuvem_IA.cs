
//   ☁️ ☁️ NUVEM I.A ☁️ ☁️
// 
// CONCEITO INICIAL: REALISAR A GESTÃO GERAL DOS INIMIGOS E DO NIVEL DE DESAFIO NO GERAL
// PARA FINS DE MELHOR INTERPRETAÇÃO DO CÓDIGO SERÁ UTILIZADO A LOGICA DE NUVEM, CHUVA E "CLIMA"
// 
// PART 01:
// A NUVEM IRÁ CAPTURAR E ARMAZENAR INFORMAÇÕES IMPORTANTES ANTES DE INICIAR OS TRABALHO
// INFORMAÇÕES PARA COLETAR: JOGADOR  .   "CHUVAS" / ONDAS DISPONIVEIS . SENÁRIO ATUAL . CASTELO//
//
// PART 02:
// A NUVEM PROJETARA COMO SERÁ TODAS AS CHAVAS, A INTENSIDADE E A FORMA QUE ELAS OCORRERAM, ELA IRA 
// DEFINIR COMO SERÁ O "DIA".
//
// -> A NUVEM IRÁ VERIFICAR EM CADA ONDA:
// TIPOS DE INIMIGOS QUE VIRAM
// QUANTIDADE DE INIMIGOS
// NIVEL DA CHUVA
// -> COM ISSO ELA IRA ALEATORIZAR COM BASE EM ESTATISTICAS QUAIS INIMIGOS E
// EM QUAIS QUANTDADES SURGIRAM, OBEDECENDO O LIMITE DE INIMIGOS E OS INIMIGOS DISPONIVEIS.
//
// -> ELA IRA GERAR UMA QUANTIDADE EXATA NA MEDIDA QUE USARA DE INIMIGOS PARA AS ONDAS EEMPLO:
// CHUVA 1: 5 A INIMIGOS CHUVA 2: 10 A INIMIGOS -> CHUVA COM MAIOR QUANTIDADE DE INIMIGOS A -
// - CHAVA 2 -> ENTÃO SERÁ GERADOS 10 INIMIGOS A.
// -> TODOS OS INIMIGOS SERAM GERADOS E DESATIVADOS PARA SEREM ATIVADOS APENAS QUANDO A ONDA INICIAR.
// 

/*
  public GameObject canvasMenu;
    public bool AtiveouNao;

    private void Update()
    {
        if (AtiveouNao == false)
        {
            canvasMenu.SetActive(false);
        }
        else
        {
            canvasMenu.SetActive(true);
        }
    }
 */

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Nuvem_IA : MonoBehaviour
{
    // PART 01: COLETA DE JOGADOR
    public string playerTag = "Jogador";
    public GameObject player; // REFERÊNCIA AO JOGADOR ENCONTRADO
    // LOCALIZA O JOGADOR CASO NÃO ACHE NENHUM OU ENCONTRE MAIS DE UM AVISA VIA LOG.
    void LocalizarJogador()
    {
        if 
            (LocalizadorDeObjetos.Tentarencontrarúnicocomtag(playerTag, out player))
            Debug.Log($"[LocalizarJogador] Jogador encontrado: {player.name}", player);
        
    }
    // -------------------------------------- PART 01: COLETA DE JOGADOR -------------------- //

    // PART 02: COLETA "CHUVAS" / ONDAS DISPONIVEIS
    public List<Chuvas_Object> listaDeChuvas = new List<Chuvas_Object>();// REFERÊNCIA AS CHUVAS ENCONTRADAS
    // LOCALIZA O NUMERO DE CHUVAS E INDENTIFICA-AS PELO NOME
    void LocalizarChuvas()
    {
        listaDeChuvas = LocalizadorDeObjetos.LocalizarTodosOsChuvas();
        string nomes = string.Join(", ", listaDeChuvas.ConvertAll(c => c.name));
        Debug.Log($"[LocalizarChuvas] Chuvas encontradas: {listaDeChuvas.Count} | {nomes}");
    }

    private void Awake()
    {
        LocalizarJogador();
        LocalizarChuvas();
    }
}
