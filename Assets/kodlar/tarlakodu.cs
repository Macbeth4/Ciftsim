using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tarlakodu : MonoBehaviour
{
    public GameObject ekinpaneli;
    public GameObject button;

    public void ekinpanelacil(){
        ekinpaneli.SetActive(true);
        button.SetActive(false);
    }
     public void kapanekinpanel(){
        ekinpaneli.SetActive(false);
        button.SetActive(true);
    }


}
