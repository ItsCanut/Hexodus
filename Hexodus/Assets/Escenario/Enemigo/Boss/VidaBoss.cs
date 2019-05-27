using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 1000f;
    public GameObject expl;
    public Transform posi;
    public int losOricos;
    public int losHierricos;
    public int laPuntuacion;
    public Transform elPlayer;
    public VidaP elPla;
    // Start is called before the first frame update

    private void Start()
    {
        elPla = GetComponent<VidaP>();
        generarMateriales();
        generarPuntuacion();
    }

    public void generarMateriales()
    {
        losOricos = Random.Range(50, 70);
        losHierricos = Random.Range(100, 140);
    }

    public void generarPuntuacion()
    {
        laPuntuacion = 10;
    }

    public void AplicarDaño(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            GameObject exp = Instantiate(expl, posi.position, Quaternion.identity);

            VidaP losMateriales = elPlayer.GetComponent<VidaP>();
            VidaP lasPuntuaciones = elPlayer.GetComponent<VidaP>();
            losMateriales.ContarMateriales(losOricos, losHierricos);
            lasPuntuaciones.subirPuntuacion(laPuntuacion);

            Destroy(gameObject);
            Destroy(exp, 1f);
        }
    }
}
