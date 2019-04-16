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
    public float shootRate;
    private float m_shootRateTimeStamp;
    public Transform player;

    GameObject objetivo;
    //public AudioClip AudioDisparo;
    
    public float reloadTime = 2.5f;
    
    public Transform posi;
    public Rigidbody bullet;

    public Transform cabeza;

    public float distanciaAtaque = 10f;

    private NavMeshAgent agente;
    public Punto VidaTorre;

    public enum EstadosRobot
    {
        Patrulla,
        Ataque
    }

    private EstadosRobot _estado = EstadosRobot.Patrulla;

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
        
        agente = GetComponent<NavMeshAgent>();
        agente.destination = punto.position;
        agente.speed = 10f;
        objetivo = GameObject.Find("Personaje_1");
        VidaTorre = GetComponent<Punto>();
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
                Vector3 targetPosition = new Vector3(objetivo.transform.position.x, 90, objetivo.transform.position.z);
                cabeza.transform.LookAt(targetPosition);
                Shoot();

                break;

            default:
                break;
        }

        // Cuando el enemigo llega al castillo
        if (Vector3.Distance(transform.position, agente.destination) <= 3f)
        {
            Destroy(gameObject);
            
            float dañoso = 50f;
            Punto puntoTorre = punto.GetComponent<Punto>();
            puntoTorre.AplicarDañoTorre(dañoso);
        }
    }


    void FX()
    {
    }
    void Shoot()
    {
       
        //transform.GetComponent<AudioSource>().PlayOneShot(AudioDisparo);
       
        
        if (Time.time > m_shootRateTimeStamp)
        {
            var clone = Instantiate(bullet, posi.position, posi.rotation);
            clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            m_shootRateTimeStamp = Time.time + shootRate;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (_estado == EstadosRobot.Ataque) Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }
}
