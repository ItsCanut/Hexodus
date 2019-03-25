using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

    //GameObjects  
    public GameObject robot;
    public int cuantosQuieroSpawnear;
    public GameObject nRonda;
    public GameObject nRestantes;
    int ronda;

    void Start()
    {

        //Enemigos que spawnean cuando iniciamos el juego.
        spawnEnemy(robot, cuantosQuieroSpawnear);
        ronda = 1;
        
        cuantosQuieroSpawnear++; // cada ronda spawnea un enemigo mas
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
        int enemigosRestantes = GameObject.FindGameObjectsWithTag("Robot").Length; // devuelve el numero de robots que hay en el mapa
        Text text = nRonda.GetComponent<Text>(); ;
        if ( enemigosRestantes == 1) // siempre habrá uno, ya que es el que clonaremos en la función de spawn.
            //Si hay más de uno significa que no has acabado con la oleada y por lo tanto no entrará en el if
        {
            spawnEnemy(robot, cuantosQuieroSpawnear);
            ronda++;
            text.text = ronda.ToString();
            // cuando solo quede un enemigo será cuando spawneen más y cuando se sumará una ronda más al marcador.           
            cuantosQuieroSpawnear++;    // cada ronda spawneará un enemigo más.     
        }

        

        Text restantes = nRestantes.GetComponent<Text>();

        //Para ponerlo en el marcador no contaremos a ese enemigo que clonamos.
        restantes.text = (enemigosRestantes - 1).ToString();

    }

    // con esta función lo que hacemos es clonar el gameobject que queramos y las veces que queramos. 
    private void spawnEnemy(GameObject elEnemigo, int cuantos)
    {
        for( int i = 0; i < cuantos; i++)
        {
            Instantiate(elEnemigo, transform.position, Quaternion.identity);
        }
    }

}

