using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chuvas_Object", menuName = "Inimigos /Chuvas_Object")]
public class Hordes_Object : ScriptableObject
{
    public string horde_name;
    public int horde_level;

    public int number_of_enemies;
    public List<Inimigo_DATA> list_of_creatures = new List<Inimigo_DATA>();

}
