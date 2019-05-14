using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMini1 : MonoBehaviour
{
    //---VARIABLES
    private NavMeshAgent agente;
    public Transform punto;
    public Punto VidaTorre;
    GameObject objetivo;
    public Transform player;
    public float distanciaAtaque = 100f;
    private float m_shootRateTimeStamp;
    public float shootRate = 1f;
    public float speedBullet = 1000f;
    public Rigidbody bullet;
    public Transform DisparoPosi;

    //--estados del enemigo
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
                agente.destination = punto.transform.position;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.destination = punto.transform.position;
        objetivo = GameObject.Find("Personaje_1");
        VidaTorre = GetComponent<Punto>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (Estado)
        {
            case EstadosRobot.Patrulla:
                agente.speed = 8f;
                agente.destination = punto.transform.position;
                if (Vector3.Distance(transform.position, player.position) < distanciaAtaque)
                {
                    Estado = EstadosRobot.Ataque;
                }
                break;
            case EstadosRobot.Ataque:
                if (Vector3.Distance(transform.position, player.position) > distanciaAtaque)
                {
                    Estado = EstadosRobot.Patrulla;
                }
                agente.destination = punto.transform.position;
                transform.LookAt(objetivo.transform.position);
                Shoot();
                break;

            default:
                break;
        }

        if (Vector3.Distance(transform.position, agente.destination) <= 3f)
        {
            Destroy(gameObject);

            float dañoso = 25f;
            Punto puntoTorre = punto.GetComponent<Punto>();
            puntoTorre.AplicarDañoTorre(dañoso);
        }
    }

    void Shoot()
    {

        //transform.GetComponent<AudioSource>().PlayOneShot(AudioDisparo);       
        if (Time.time > m_shootRateTimeStamp)
        {
            var cloneBullet = Instantiate(bullet, DisparoPosi.position, DisparoPosi.rotation);
            cloneBullet.velocity = DisparoPosi.TransformDirection(new Vector3(0, speedBullet, 0));
            m_shootRateTimeStamp = Time.time + shootRate;
        }
    }
}
