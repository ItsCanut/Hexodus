using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public ArrayList listaCosas;


    public void Añadir(GameObject item)
    {
        listaCosas.Add(item);
    }
    public void Borrar(GameObject item)
    {
        listaCosas.Remove(item);
    }
}
