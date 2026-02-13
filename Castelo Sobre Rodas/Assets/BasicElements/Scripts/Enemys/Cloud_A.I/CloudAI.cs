
//   ☁️ ☁️ CLOUD I.A ☁️ ☁️
// 
// CONCEITO INICIAL: REALISAR A GESTÃO GERAL DOS INIMIGOS E DO NIVEL DE DESAFIO NO GERAL
// PARA FINS DE MELHOR INTERPRETAÇÃO DO CÓDIGO SERÁ UTILIZADO A LOGICA DE NUVEM, CHUVA E "CLIMA"
// 
// PART 01:
// A NUVEM IRÁ CAPTURAR E ARMAZENAR INFORMAÇÕES IMPORTANTES ANTES DE INICIAR OS TRABALHO
// INFORMAÇÕES PARA COLETAR: JOGADOR  .   "CHUVAS" / ONDAS DISPONIVEIS . SENÁRIO ATUAL . CASTELO//
//
// PART 02:
// A NUVEM PROJETARA COMO SERÁ TODAS AS CHUVAS, A INTENSIDADE E A FORMA QUE ELAS OCORRERAM, ELA IRA 
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
using System.Collections.Generic;
using UnityEngine;

public class CloudAI : MonoBehaviour
{
    // PART 01: LOCALIZA O JOGADOR COM A TAG "Player"

    public string playerTag = "Player";  // <- NOME DA TAG NO OBJETO DEDICADO AO JOGADOR
    public GameObject player;            // <- REFERÊNCIA AO JOGADOR ENCONTRADO

   
    void Findplayer() // LOCALIZA O JOGADOR CASO NÃO ACHE NENHUM OU ENCONTRE MAIS DE UM AVISA VIA LOG.
    { 
     if 
     (ObjectLocator.findtag(playerTag, out player)) // CASO NÃO ENCONTRE NENHUM OBJETO COM A TAG "Player" Retorna False
      Debug.Log
                ($"[LocalizarJogador] Jogador encontrado: {player.name}", player);

    }
    // -------------------------------------- PART 01: COLETA DE JOGADOR -------------------- //

    // PART 01: COLETA "CHUVAS" / ONDAS DISPONIVEIS
    public List<Chuvas_Object> Cloud_List = new List<Chuvas_Object>();   // <-  REFERÊNCIA AS CHUVAS ENCONTRADAS

   
    List<Chuvas_Object> FindClouds() // LOCALIZA O NUMERO DE CHUVAS E INDENTIFICA-AS PELO NOME
    {
        Cloud_List = ObjectLocator.LocalizarTodosOsChuvas(); // <- LOCALIZA A CHUVA DE INIMIGOS UM POR UM EM: Assets > Resorces > Chuvas.
        string names = string.Join(", ", Cloud_List.ConvertAll(c => c.name));
        Debug.Log($"[LocalizarChuvas] Chuvas encontradas: {Cloud_List.Count} | {names}");

       if(Cloud_List != null)
        {
            return Cloud_List;
        }
       else
        {
            return null;
        }
    }

    // -------------------------------------- PART 01: COLETA DE CHUVA -------------------- //
    // DEFINIÇÃO DE RUN / DIA
    // CADA DIA TERÁ UMA MÉDIA DE 10 CHUVAS, MAS NÃO SERÁ NECESSÁRIAMENTE CHUVAS PODERAM SER DIAS ENSOLARADOS = SEM INIMIGOS.
    // PARA MOMENTOS SEM CHUVA HAVERÁ UM TIMER PARA DEFINIR O FIM
    // PARA CADA CHUVA O FIM SERÁ DEFINIDO APENAS QUANDO O ULTIMO INIMIGO MORRER.

    public int MinimumRainfall = 10;

    public void GenerateRain()
    {
        // VALIDA SE AS NUVENS SÃO EM QUANTIDADE CORRETA E PODE VAIDAR SE ESTÃO NOS PADRÕES ESPERADOS
        GenerateRainFunctions.ValidateClouds(this, MinimumRainfall); 
        // GERA AS NUVENS COM FORME AS QUANTIDADES ESPERADAS
        GenerateRainFunctions.GenerateDay(Cloud_List,  MinimumRainfall);
        // GERA OS INIMIGOS E OS DESATIVA PARA SEREM ATIVADOS APÓS O INICIO DA CHUVA EM JOGO
        GenerateRainFunctions.GenerateRainForWave(Cloud_List);


    }


    private void Awake()
    {
        Findplayer();
        FindClouds();
        GenerateRain();
    }
}
