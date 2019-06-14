using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejoras : MonoBehaviour
{

    public string nombreMejora;
    public string descripcionMejora;
    public double precioMejora;
    public int index;


    public int GetIndex()
    {
        return this.index;
    }
    public string GetNombre()
    {
        return this.nombreMejora;
    }

    public string GetDescripcion()
    {
        return this.descripcionMejora;
    }

    public double GetPrecio()
    {
        return this.precioMejora;
    }
}
