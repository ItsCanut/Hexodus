using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniFuente : MonoBehaviour
{
     private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.Play("AniFuente");
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
