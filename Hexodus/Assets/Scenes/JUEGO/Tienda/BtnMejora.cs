using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BtnMejora : MonoBehaviour
{

    private string nombreMejora;
    private string descripcionMejora;
    private double precioMejora;
    public double Puntuacion;
    public Text textoPuntuacion;

    public Text nombreInspector;
    public Text descripcionInspector;
    public Text precioInspector;


    public Button MejoraA_1, MejoraA_2, MejoraA_3, MejoraB_1, MejoraB_2, MejoraB_3, MejoraC_1, MejoraC_2, MejoraC_3;

    private Mejoras scriptMejoras;

    private double PrecioObjeto;

    public GameObject player;
    private int velocidad;
    private int danyo;
    private int vida;

    private void Start()
    {
        Puntuacion = 1000;
        textoPuntuacion.text = Puntuacion.ToString();
        velocidad = 0;
        vida = 0;
        danyo = 0;
    }
    private void Update()
    {
        MejoraA_1.onClick.AddListener(delegate { EditarInspector(MejoraA_1.GetComponent<Mejoras>().GetNombre(), MejoraA_1.GetComponent<Mejoras>().GetDescripcion(), MejoraA_1.GetComponent<Mejoras>().GetPrecio(), MejoraA_1.GetComponent<Mejoras>().GetIndex()); });
        MejoraA_2.onClick.AddListener(delegate { EditarInspector(MejoraA_2.GetComponent<Mejoras>().GetNombre(), MejoraA_2.GetComponent<Mejoras>().GetDescripcion(), MejoraA_2.GetComponent<Mejoras>().GetPrecio(), MejoraA_2.GetComponent<Mejoras>().GetIndex()); });
        MejoraA_3.onClick.AddListener(delegate { EditarInspector(MejoraA_3.GetComponent<Mejoras>().GetNombre(), MejoraA_3.GetComponent<Mejoras>().GetDescripcion(), MejoraA_3.GetComponent<Mejoras>().GetPrecio(), MejoraA_3.GetComponent<Mejoras>().GetIndex()); });

        MejoraB_1.onClick.AddListener(delegate { EditarInspector(MejoraB_1.GetComponent<Mejoras>().GetNombre(), MejoraB_1.GetComponent<Mejoras>().GetDescripcion(), MejoraB_1.GetComponent<Mejoras>().GetPrecio(), MejoraB_1.GetComponent<Mejoras>().GetIndex()); });
        MejoraB_2.onClick.AddListener(delegate { EditarInspector(MejoraB_2.GetComponent<Mejoras>().GetNombre(), MejoraB_2.GetComponent<Mejoras>().GetDescripcion(), MejoraB_2.GetComponent<Mejoras>().GetPrecio(), MejoraB_2.GetComponent<Mejoras>().GetIndex()); });
        MejoraB_3.onClick.AddListener(delegate { EditarInspector(MejoraB_3.GetComponent<Mejoras>().GetNombre(), MejoraB_3.GetComponent<Mejoras>().GetDescripcion(), MejoraB_3.GetComponent<Mejoras>().GetPrecio(), MejoraB_3.GetComponent<Mejoras>().GetIndex()); });

        MejoraC_1.onClick.AddListener(delegate { EditarInspector(MejoraC_1.GetComponent<Mejoras>().GetNombre(), MejoraC_1.GetComponent<Mejoras>().GetDescripcion(), MejoraC_1.GetComponent<Mejoras>().GetPrecio(), MejoraC_1.GetComponent<Mejoras>().GetIndex()); });
        MejoraC_2.onClick.AddListener(delegate { EditarInspector(MejoraC_2.GetComponent<Mejoras>().GetNombre(), MejoraC_2.GetComponent<Mejoras>().GetDescripcion(), MejoraC_2.GetComponent<Mejoras>().GetPrecio(), MejoraC_2.GetComponent<Mejoras>().GetIndex()); });
        MejoraC_3.onClick.AddListener(delegate { EditarInspector(MejoraC_3.GetComponent<Mejoras>().GetNombre(), MejoraC_3.GetComponent<Mejoras>().GetDescripcion(), MejoraC_3.GetComponent<Mejoras>().GetPrecio(), MejoraC_3.GetComponent<Mejoras>().GetIndex()); });



        // -------------- MEJORAS DE VELOCIDAD DE MOVIMIENTO ---------------------
        if (velocidad.Equals(1))
        {
            player.GetComponent<Movimiento_Player>().velocidad = player.GetComponent<Movimiento_Player>().velocidad + 1f;
        }
        if (velocidad.Equals(2))
        {
            player.GetComponent<Movimiento_Player>().velocidad = player.GetComponent<Movimiento_Player>().velocidad + 1f;
        }
        if (velocidad.Equals(3))
        {
            player.GetComponent<Movimiento_Player>().velocidad = player.GetComponent<Movimiento_Player>().velocidad + 1f;
        }

        // -------------- MEJORAS DE VIDA ---------------------
        if (vida.Equals(1))
        {
            player.GetComponent<VidaP>().vida = player.GetComponent<VidaP>().vida + 50f;
        }
        if (vida.Equals(2))
        {
            player.GetComponent<VidaP>().vida = player.GetComponent<VidaP>().vida + 50f;
        }
        if (vida.Equals(3))
        {
            player.GetComponent<VidaP>().vida = player.GetComponent<VidaP>().vida + 50f;
        }

        // -------------- MEJORAS DE DAÑO DE ATAQUE  -------------------------------
        if (danyo.Equals(1))
        {
            player.GetComponent<BulletHit>().daño = player.GetComponent<BulletHit>().daño + 10;
        }
        if (danyo.Equals(2))
        {
            player.GetComponent<BulletHit>().daño = player.GetComponent<BulletHit>().daño + 10;
        }
        if (danyo.Equals(3))
        {
            player.GetComponent<BulletHit>().daño = player.GetComponent<BulletHit>().daño + 10;
        }
    }


    // --- Actualiza los valores del inspector en base a que mejora se ha seleccionado ---
    void EditarInspector(string nombre,string descripcion,double precio,int index)
    {
         nombreInspector.text = nombre.ToString();
         descripcionInspector.text = descripcion.ToString();


        if(Puntuacion - precio < 0)
        {
            PrecioObjeto = precio;
            precioInspector.text = "Precio: " + precio.ToString();
            precioInspector.color = Color.red;
        }
        else
        {
            PrecioObjeto = precio;
            precioInspector.text = "Precio: " + precio.ToString();
        }
        

        
    }

    public void Comprar()
    {

        if (Puntuacion - PrecioObjeto < 0)
        {
            Debug.Log("NO HAY SUFICIENTE DINERO");
        }
        else
        {
            Puntuacion = Puntuacion - PrecioObjeto;
            textoPuntuacion.text = Puntuacion.ToString();
            velocidad = velocidad + 1;
            danyo = danyo + 1;
            vida = vida + 1;
        }

    }
}
