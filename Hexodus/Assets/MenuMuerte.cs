﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{

   

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main_Menu");
        }
        
    }
        
    

    
}
