using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    //---VARIABLES
    private NavMeshAgent agente;
    public Transform punto;
    GameObject objetivo;
    public Punto VidaTorre;
    
    public Transform player;
    public float distanciaAtaque = 100f;
    public Transform cabeza;
    private float m_shootRateTimeStamp;
    public float shootRate = 1f;
    public float speedBullet = 1000f;
    public Transform DisparoI;
    public Transform DisparoD;
    //false=izq ; true=der
    private bool AlternarDisparo = false;
    public GameObject efectoI;
    public GameObject efectoD;
    public Rigidbody bullet;
    public Transform robotito;
    public Transform salidaRobotito;

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
    }//fin start

    // Update is called once per frame
    void Update()
    {
        switch (Estado)
        {
            case EstadosRobot.Patrulla:
                agente.speed = 4f;
                agente.destination = punto.transform.position;
                efectoI.SetActive(false);
                efectoD.SetActive(false);

                if (Vector3.Distance(transform.position, player.position) < distanciaAtaque)
                {
                    Estado = EstadosRobot.Ataque;
                }
                break;

            case EstadosRobot.Ataque:               
                if (Vector3.Distance(transform.position, player.position) > distanciaAtaque)
                {
                    var cloneRobotito = Instantiate(robotito, salidaRobotito.position, salidaRobotito.rotation);
                    
                    Estado = EstadosRobot.Patrulla;
                }
                agente.destination = objetivo.transform.position;
                agente.speed = 3f;

                //--Aqui se pone para que dispare al jugador               
                //Vector3 targetPosition = new Vector3(objetivo.transform.position.x, 90, objetivo.transform.position.z);
                transform.LookAt(objetivo.transform.position);
                Shoot();
                break;

            default:
                break;
        }

        // Cuando el enemigo llega al castillo
        if (Vector3.Distance(transform.position, punto.position) <= 3f)
        {
            Destroy(gameObject);

            float dañoso = 500f;
            Punto puntoTorre = punto.GetComponent<Punto>();
            puntoTorre.AplicarDañoTorre(dañoso);
        }

    } //fin update

    void FX()
    {
        efectoI.SetActive(false);
        efectoD.SetActive(false);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (_estado == EstadosRobot.Ataque) Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }

    void Shoot()
    {

        //transform.GetComponent<AudioSource>().PlayOneShot(AudioDisparo);       
        if (Time.time > m_shootRateTimeStamp)
        {            
            if (AlternarDisparo==false)
            {
                efectoI.SetActive(true);
                Invoke("FX", 0.5f);
                var cloneBullet = Instantiate(bullet, DisparoI.position, DisparoI.rotation);
                cloneBullet.velocity = DisparoI.TransformDirection(new Vector3(0, speedBullet, 0));
                m_shootRateTimeStamp = Time.time + shootRate;
                AlternarDisparo = true;
            }
        }
        if (Time.time > m_shootRateTimeStamp)
        {
            if (AlternarDisparo == true)
            {
                efectoD.SetActive(true);
                Invoke("FX", 0.5f);
                var cloneBullet = Instantiate(bullet, DisparoD.position, DisparoD.rotation);
                cloneBullet.velocity = DisparoD.TransformDirection(new Vector3(0, -speedBullet, 0));
                m_shootRateTimeStamp = Time.time + shootRate;
                AlternarDisparo = false;
            }
        }
    }
}
