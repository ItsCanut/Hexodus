using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMagico : MonoBehaviour
{
    public float health = 200f;
    public Transform elPlayer;
    public VidaP elPla;
    public GameObject expl;

    public int losOrbicos;
    public int laPuntuacion;

    // Start is called before the first frame update
    private void Start()
    {
        elPla = GetComponent<VidaP>();
        generarMateriales();
        generarPuntuacion();
    }

    public void generarMateriales()
    {
        losOrbicos = Random.Range(2, 5);
    }

    public void generarPuntuacion()
    {
        laPuntuacion = 1;
    }
    public void AplicarDaño(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            VidaP losMateriales = elPlayer.GetComponent<VidaP>();
            VidaP lasPuntuaciones = elPlayer.GetComponent<VidaP>();
            losMateriales.ContarOrbes(losOrbicos);
            lasPuntuaciones.subirPuntuacion(laPuntuacion);

            GameObject exp = Instantiate(expl, transform.position, Quaternion.identity);

            Destroy(this.gameObject);

            Destroy(exp, 1f);
        }
    }
}
