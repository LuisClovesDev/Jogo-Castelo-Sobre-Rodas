using System.Collections.Generic;
using UnityEngine;

public class ObjectLocator
{
    public static bool findtag(string tag, out GameObject result)
    {
        result = null;

        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        // LOCALIZAR LISTA DE OBJETOS COM A TAG
        // CASO LOCALIZE TAG "Player" DEVOLVE UM OU MAIS OBJETOS COM PLAYER.


        if (objects.Length == 0)
        {
            Debug.LogError
                ($"[SceneObjectFinder] Nenhum GameObject com a tag '{tag}' foi encontrado!");
            return false;
        }

        if (objects.Length > 1)
        {
            Debug.LogError
                ($"[SceneObjectFinder] Mais de um GameObject com a tag '{tag}' foi encontrado! Acao cancelada.");
            foreach (var obj in objects)
            {
                Debug.Log($" - Encontrado: {obj.name}", obj);
            }

            return false;
        }

        result = objects[0];
        return true;
    }
    //----------------------------------------------
    public static List<Chuvas_Object>  LocalizarTodosOsChuvas()
    {
        Chuvas_Object[] encontrados = Resources.LoadAll<Chuvas_Object>("Chuvas");

        List<Chuvas_Object> lista = new List<Chuvas_Object>();
        lista.AddRange(encontrados);

        return lista;
    }
}
