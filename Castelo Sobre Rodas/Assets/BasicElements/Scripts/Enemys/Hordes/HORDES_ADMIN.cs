using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ======================================================
// ADMINISTRADOR
// ======================================================
public class HORDES_ADMIN : MonoBehaviour
{
    // GERENCIAR OS INIMIGOS CRIADOS

    // IDENTIFICAR INIMIGOS CRIADOS

    public List<Enemy> Enemys = new List<Enemy>();

    public Dictionary<string, List<Enemy>> grupos = new Dictionary<string, List<Enemy>>();
    void Group_By_Name()
    {
        grupos.Clear();

        foreach (Enemy e in Enemys)
        {
            string chave = e.gameObject.name; // pode trocar depois

            // Se ainda não existe esse grupo, cria
            if (!grupos.ContainsKey(chave))
            {
                grupos[chave] = new List<Enemy>();
            }

            // Adiciona no grupo correto
            grupos[chave].Add(e);
        }
    }
    void Print_Groups()
    {
       
            
            Debug.Log($"quantidade de listas {grupos.Count}");

        var primeiraLista = grupos.Values.ToList()[0];

        int quantidade_de_listas = grupos.Count;
        int quantidade_de_inimigos_na_lista = primeiraLista.Count;

        Debug.Log($"quantidade de inimigos na primeira lista {quantidade_de_inimigos_na_lista}");

        for (int i = 0; i < 2; i++)
        {
            if (i < primeiraLista.Count)
            {
                primeiraLista[i].gameObject.SetActive(true);
            }
        }


    }
    void Awake()
    {
        Enemy[] todos = Resources.FindObjectsOfTypeAll<Enemy>();

        foreach (Enemy e in todos)
        {
            // FILTRO IMPORTANTE
            if (e.gameObject.scene.isLoaded)
            {
                Enemys.Add(e);
            }
        }
        Debug.Log("Inimigos Encontrados: " + Enemys.Count);
        Group_By_Name();
        Print_Groups();
    }

}
