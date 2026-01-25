
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
using Unity.VisualScripting;
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
            (LocalizadorDeObjetos.TentarencontrarUnicocomtag(playerTag, out player))
            Debug.Log($"[LocalizarJogador] Jogador encontrado: {player.name}", player);
        
    }
    // -------------------------------------- PART 01: COLETA DE JOGADOR -------------------- //

    // PART 01: COLETA "CHUVAS" / ONDAS DISPONIVEIS
    public List<Chuvas_Object> listaDeChuvas = new List<Chuvas_Object>();// REFERÊNCIA AS CHUVAS ENCONTRADAS
                                                                         // LOCALIZA O NUMERO DE CHUVAS E INDENTIFICA-AS PELO NOME
    List<Chuvas_Object> LocalizarChuvas()
    {
        listaDeChuvas = LocalizadorDeObjetos.LocalizarTodosOsChuvas();
        string nomes = string.Join(", ", listaDeChuvas.ConvertAll(c => c.name));
        Debug.Log($"[LocalizarChuvas] Chuvas encontradas: {listaDeChuvas.Count} | {nomes}");

       if(listaDeChuvas != null)
        {
            return listaDeChuvas;
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

    public int Chuva_Atual;
    public int Minimo_de_Chuvas = 10;

    public void Gerar_Chuva()
    {
        List<Chuvas_Object> chuvas = LocalizarChuvas();
        
        int quantidade_de_chuvas = listaDeChuvas.Count;
        if(quantidade_de_chuvas < Minimo_de_Chuvas)
        {
            Debug.Log(
                "A Quantidade de chuvas coletadas está abaixo do minimo exigido \n"+
                "Chuavas Coletadas" +quantidade_de_chuvas + "\n" +
                "Chuvas necessárias" +Minimo_de_Chuvas
                );
            return;
        }
        else
        {
            Debug.Log("CHUVAS: " + chuvas);
            for(int i = 0; i < Minimo_de_Chuvas; i++)
            {
                Aleatorizador.SortearInimigo(chuvas[i].itens);
            }
        }

    }


    private void Awake()
    {
        LocalizarJogador();
        LocalizarChuvas();
        Gerar_Chuva();
    }
}
