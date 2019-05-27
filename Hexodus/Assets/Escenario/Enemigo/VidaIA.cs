using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaIA : MonoBehaviour
{
    public float health = 200f;
    public Transform elPlayer;
    public VidaP elPla;
    public GameObject expl;

    public int losOricos;
    public int losHierricos;
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
        losOricos = Random.Range(4, 10);
        losHierricos = Random.Range(4, 21);
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
            losMateriales.ContarMateriales(losOricos, losHierricos);
            lasPuntuaciones.subirPuntuacion(laPuntuacion);

            GameObject exp = Instantiate(expl, transform.position, Quaternion.identity);

            Destroy(this.gameObject);

            Destroy(exp, 1f);
        }
    }
}
