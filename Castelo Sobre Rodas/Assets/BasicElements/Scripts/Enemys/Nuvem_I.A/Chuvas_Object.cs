using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chuvas_Object", menuName = "Inimigos /Chuvas_Object")]
public class Chuvas_Object : ScriptableObject
{
    public string nome_da_chuva;
    public int nivel_da_chuva;

    public List<Inimigo_DATA> itens = new List<Inimigo_DATA>();

}
