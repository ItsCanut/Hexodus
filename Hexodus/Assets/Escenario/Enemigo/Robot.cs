using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    //--disparo enemigo
    public float speedBullet = 1000f;
    public int Dano = 5;
    public float shootRate = 1f;
    private float m_shootRateTimeStamp;

    public static Robot instace;
    public int CurrentScore;



    public Transform posi;
    public Rigidbody bullet;
    public float distanciaAtaque = 13f;

    //--audio y efecto enemigo
    //public AudioClip AudioDisparo;
    public GameObject efecto;

    //--caracteristicas y posicionamiento enemigo
    public Transform punto;
    public Transform player;
    GameObject objetivo;
    public Transform cabeza;
    private static NavMeshAgent agente;
    public float speed = 5f;
    public Punto VidaTorre;


   // public AudioClip sonidoCaminar;
   // public AudioSource aS;



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
        bool congAct = gameObject.GetComponent<CaracteristicasHielo>();
        agente = GetComponent<NavMeshAgent>();
        agente.destination = punto.transform.position;

        instace = this;

        objetivo = GameObject.Find("Personaje_1");
        VidaTorre = GetComponent<Punto>();

        //aS.clip = sonidoCaminar;
        //aS.Play();

    }//fin start

    // Update is called once per frame
    void Update()
    {

        switch (Estado)
        {
            case EstadosRobot.Patrulla:

                agente.speed = 8f;


                efecto.SetActive(false);

                if (Vector3.Distance(transform.position, player.position) < distanciaAtaque)
                {
                    Estado = EstadosRobot.Ataque;
                }
                break;

            case EstadosRobot.Ataque:


                agente.speed = 5f;



                if (Vector3.Distance(transform.position, player.position) > distanciaAtaque)
                {
                    Estado = EstadosRobot.Patrulla;
                }

                //--Aqui se pone para que dispare al jugador               
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

            float dañoso = 75f;
            Punto puntoTorre = punto.GetComponent<Punto>();
            puntoTorre.AplicarDañoTorre(dañoso);
        }

    } //fin update
    void FX()
    {
        efecto.SetActive(false);
    }
    void Shoot()
    {

        //transform.GetComponent<AudioSource>().PlayOneShot(AudioDisparo);       
        if (Time.time > m_shootRateTimeStamp)
        {
            efecto.SetActive(true);
            Invoke("FX", 0.5f);
            var cloneBullet = Instantiate(bullet, posi.position, posi.rotation);
            cloneBullet.velocity = cabeza.TransformDirection(new Vector3(0, -speedBullet, 0));
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
