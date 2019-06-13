using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NombreJugador : MonoBehaviour
{

    public GameObject campoTexto;
    void Start()
    {
        InputField input = campoTexto.GetComponent<InputField>();
        input.onEndEdit.AddListener(SubmitName);
        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        PlayerPrefs.SetString("JugadorActual", arg0);
    }
}
