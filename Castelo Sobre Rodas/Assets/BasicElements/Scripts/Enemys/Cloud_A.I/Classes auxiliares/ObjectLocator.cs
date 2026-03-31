using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe utilitaria responsavel por localizar objetos no projeto.
/// 
/// Funcoes:
/// - Buscar GameObject por tag
/// - Carregar dados de recursos (chuvas)
/// </summary>
public class ObjectLocator
{
    // ======================================================
    // BUSCA DE OBJETO POR TAG
    // ======================================================

    /// <summary>
    /// Localiza um unico GameObject na cena com a tag especificada.
    /// </summary>
    /// <param name="tag">Tag do objeto a ser localizado</param>
    /// <param name="result">Objeto encontrado</param>
    /// <returns>
    /// true  = encontrou exatamente um objeto  
    /// false = nenhum ou mais de um encontrado
    /// </returns>
    public static bool findtag(string tag, out GameObject result)
    {
        result = null;

        // Busca todos os objetos com a tag informada
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        // --------------------------------------------------
        // VALIDACAO DOS RESULTADOS
        // --------------------------------------------------

        // Nenhum objeto encontrado
        if (objects.Length == 0)
        {
            Debug.LogError(
                "[SceneObjectFinder] Nenhum GameObject com a tag '" + tag + "' foi encontrado!"
            );
            return false;
        }

        // Mais de um objeto encontrado (erro de configuracao)
        if (objects.Length > 1)
        {
            Debug.LogError(
                "[SceneObjectFinder] Mais de um GameObject com a tag '" + tag + "' foi encontrado! Acao cancelada."
            );

            // Lista todos os objetos encontrados para facilitar debug
            foreach (var obj in objects)
            {
                Debug.Log(" - Encontrado: " + obj.name, obj);
            }

            return false;
        }

        // Caso correto: apenas um objeto encontrado
        result = objects[0];
        return true;
    }

    // ======================================================
    // CARREGAMENTO DE CHUVAS (RESOURCES)
    // ======================================================

    /// <summary>
    /// Carrega todos os objetos do tipo Rains_Object
    /// localizados na pasta Resources/Chuvas.
    /// </summary>
    /// <returns>Lista de chuvas encontradas</returns>
    public static List<Rains_Object> LocalizarTodosOsChuvas()
    {
        // Carrega todos os assets do tipo Rains_Object dentro da pasta "Chuvas"
        Rains_Object[] encontrados = Resources.LoadAll<Rains_Object>("Chuvas");

        // Converte array para lista
        List<Rains_Object> lista = new List<Rains_Object>();
        lista.AddRange(encontrados);

        return lista;
    }
}