using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Threading;

public class Spawner2 : MonoBehaviour
{

    //declaraciones  
    public GameObject robot;
    public int cuantosQuieroSpawnear;
    int ronda;
    float waveTimer = 7.0f;
    float timeTillWave = 0.0f;
    int contWaves;
    int cuantasWaves;
    bool spawn;
    bool sumaWaves;
   

    void Start()
    {

        //Enemigos que spawnean cuando iniciamos el juego.
        ronda = 1;
        contWaves = 0;
        spawn = true;
        cuantasWaves = 1;
    }

    // Draws a cube to show where the spawn point is... Useful if you don't have a object that show the spawn point
    void OnDrawGizmos()
    {
        // Sets the color to red
        Gizmos.color = Color.red;
        //draws a small cube at the location of the gam object that the script is attached to
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
    }

    void Update()
    {
        int enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemigo").Length; // devuelve el numero de robots que hay en el mapa

        if (contWaves >= cuantasWaves && enemigosRestantes.Equals(2))
        {
            ronda++;
            contWaves = 0;
            spawn = true;
            sumaWaves = true;
        }

        if (contWaves < cuantasWaves && spawn)
        {
            spawnTimed(robot);
        }

    }

    // con esta función lo que hacemos es clonar el gameobject que queramos y las veces que queramos. 
    private void spawnEnemy(GameObject elEnemigo, int cuantos)
    {
        for (int i = 0; i < cuantos; i++)
        {
            Instantiate(elEnemigo, transform.position, Quaternion.identity);
        }
    }

    private void spawnTimed(GameObject elEnemigo)
    {
        timeTillWave += Time.deltaTime;
        if (timeTillWave >= waveTimer)
        {
            spawnEnemy(robot, cuantosQuieroSpawnear);
            contWaves++;
            timeTillWave = 0.0f;
        }
        if (ronda % 2 == 0 && sumaWaves == true)
        {
            sumaWaves = false;
            cuantosQuieroSpawnear++;
            cuantasWaves++;
        }

    }
}



