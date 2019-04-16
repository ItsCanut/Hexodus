using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionHUD : MonoBehaviour
{
    public GameObject HUD;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tiempo());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Tiempo ()
    {
        yield return new WaitForSeconds(2);
        HUD.SetActive(true);
    }

}
