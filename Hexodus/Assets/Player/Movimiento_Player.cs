using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Player : MonoBehaviour
{

    public float velocidad = 0f;

    public float caminar = 4f;

    GameObject suelo;

    public bool inFloor;

    public float jumpHeight = 7f;

    private Rigidbody rb;

    public float dashSpeed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inFloor = true;
        StartCoroutine(Tiempo());
    }

    IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(4);
        velocidad=11f;
    }

    IEnumerator Tiempo2()
    {
        yield return new WaitForSeconds(0.4f);
        velocidad = 11f;
    }

    // Update is called once per frame
    void Update()
    {

        bool shiftPulsado = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isDashingW = Input.GetKey(KeyCode.LeftAlt);

        Vector3 movimiento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (shiftPulsado)
        {
            transform.Translate(movimiento * (Time.deltaTime * caminar));
        }
        if (isDashingW)
        {
            dashSpeed = 6f;            
            velocidad = velocidad + dashSpeed;
            StartCoroutine(Tiempo2());
           

        }
        else { 
        transform.Translate(movimiento * (Time.deltaTime * velocidad));
        }
    }

    private void FixedUpdate()
    {
        

        Saltar();
        

    }
    

    private void Saltar()
    {
        // salto cuando doy doy click al espacio
        if (Input.GetButtonDown("Jump"))
        {
            if (inFloor)
            {
                rb.AddForce(Vector3.up * jumpHeight);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Suelo")
        {
            inFloor = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Suelo")
        {
            inFloor = false;
        }
    }

   
}
