using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    public int Vida = 100;
    //public Transform Objetivo;
    public Transform PuntoDisparo;

    //public Rigidbody projectile;
    public float speed = 20f;
    public int Dano = 10;
    public float range = 10f;
    //public AudioClip AudioDisparo;
    public GameObject efecto;

    public Transform punto;

    public Transform player;

    public Transform cabeza;

    public float distanciaAtaque = 10f;

    private NavMeshAgent agente;

    public enum EstadosRobot
    {
        Patrulla,
        Ataque
    }

    private EstadosRobot _estado = EstadosRobot.Patrulla;
    private GameObject gameObject;

    public Robot(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public EstadosRobot Estado
    {
        get
        {
            return _estado;
        }
        set
        {
            _estado = value;
            if (_estado == EstadosRobot.Patrulla)
            {
                agente.destination = punto.position;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        efecto.active = false;
        agente = GetComponent<NavMeshAgent>();
        agente.destination = punto.position;
        agente.speed = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Estado)
        {
            case EstadosRobot.Patrulla:

               
                agente.destination = punto.position;
                agente.speed = 4f;
                //Debug.Log("MODO PATRULLA");
                efecto.active = false;


                if (Vector3.Distance(transform.position, player.position) < distanciaAtaque)
                {
                    Estado = EstadosRobot.Ataque;
                }
                break;

            case EstadosRobot.Ataque:

                agente.destination = punto.position;
                agente.speed = 2f;
                if (Vector3.Distance(transform.position, player.position) > distanciaAtaque)
                {
                    Estado = EstadosRobot.Patrulla;
                }
                //Aqui se pone para que dispare al jugador
                Debug.Log("MODO ATAQUE");
                cabeza.transform.LookAt(player);
                Shoot();
                
                break;

            default:
                break;
        }
    }

    
    void FX()
    {
        efecto.active = false;
    }
    void Shoot()
    {
        RaycastHit hit;
        //transform.GetComponent<AudioSource>().PlayOneShot(AudioDisparo);
        efecto.active = true;
        Invoke("FX", 0.2f);

        if (Physics.Raycast(PuntoDisparo.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Debug.Log("Estoy en el rango para darle al jugador");

            Debug.Log(hit.transform.name);
            VidaP target = hit.transform.GetComponent<VidaP>();
            if (target != null)
            {

                target.AplicarDano(Dano);
            }
            /* Debug.Log(hit.transform.name);
             VidaIA target = hit.transform.GetComponent<VidaIA>();
             if (target != null)
             {

                 target.AplicarDaño(Dano);
             }*/
        }

    }
   
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (_estado == EstadosRobot.Ataque) Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }
}
