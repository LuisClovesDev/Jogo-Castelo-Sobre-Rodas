using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Aleatorizador : MonoBehaviour
{  
    // GERAR LISTA DE INIMIGOS
    public List<Inimigo_DATA> GerarInimigos(int Numero_de_Inimigos)
    {
        List<Inimigo_DATA> resultado = new List<Inimigo_DATA>();

        for (int i = 0; i < Numero_de_Inimigos; i++)
        {
            Inimigo_DATA inimigo = SortearInimigo();
            if (inimigo != null)
                resultado.Add(inimigo);
        }

        return resultado;
    }

    // ALEATORIZAR INIMIGOS COM BASE DE PORCENTAGENS
    public List<Inimigo_DATA> Tipos_de_Inimigos;
    Inimigo_DATA SortearInimigo()
    {
        float sorteio = Random.Range(0f, 100f);

        // 0–10% → Life > 10
        if (sorteio < 10f)
        {
            var candidatos = Tipos_de_Inimigos
                .Where(i => i.Nivel_de_Desafio > 10)
                .ToList();

            return SorteioSimples(candidatos);
        }

        // 10–60% → Life > 40 (50%)
        else if (sorteio < 60f)
        {
            var candidatos = Tipos_de_Inimigos
                .Where(i => i.Nivel_de_Desafio > 40)
                .ToList();

            return SorteioSimples(candidatos);
        }

        // 60–100% → qualquer inimigo (ou outro critério)
        else
        {
            return SorteioSimples(Tipos_de_Inimigos);
        }
    }
    Inimigo_DATA SorteioSimples(List<Inimigo_DATA> lista)
    {
        if (lista == null || lista.Count == 0)
            return null;

        int index = Random.Range(0, lista.Count);
        return lista[index];
    }

}
