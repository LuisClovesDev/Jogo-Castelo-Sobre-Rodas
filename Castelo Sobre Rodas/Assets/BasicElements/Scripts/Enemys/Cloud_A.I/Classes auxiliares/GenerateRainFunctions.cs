using System.Collections.Generic;
using UnityEngine;

public class GenerateRainFunctions : MonoBehaviour
{

    public CloudAI ClaudAI;
    public int CurrentRain;
    
    public static List<Chuvas_Object> ValidateClouds(CloudAI cloudAI, int minimumRainfall)
    {
        List<Chuvas_Object> clouds = cloudAI.Cloud_List;


        int quantidade_de_chuvas = cloudAI.Cloud_List.Count;

        if (quantidade_de_chuvas < minimumRainfall)
        {
            Debug.Log(
                "A Quantidade de chuvas coletadas está abaixo do minimo exigido \n" +
                "Chuavas Coletadas" + quantidade_de_chuvas + "\n" +
                "Chuvas necessárias" + minimumRainfall
                );
            return null; // <- JOGO PODERA CRACHAR MAS O AVISO DE ERRO IRÁ INDENTIFICAR O EERRO.
        }
        else
        {
            return clouds; // <- retorna as nuvens
        }
    }
    public static void GenerateDay(List<Chuvas_Object> clouds, int minimumRainfall) 
        // GERA O DIA DE ACORDO COM AS CHUVAS ELE ALEATORIZA OS INIMIGOS EM CASA CHUVA
    {
        Debug.Log("CHUVAS: " + clouds);
        for (int i = 0; i < minimumRainfall; i++)
        {
            Randomizer.DrawEnemy(clouds[i].Creature);
            clouds[i].enemiesnumber = minimumRainfall;

           
        }
    }

    public static void GenerateRainForWave(List<Chuvas_Object> clouds)
    {
        int i = 0;
        List<Inimigo_DATA> enemyTypes = clouds[i].Creature;
        // spaw enemy


    }
}
