using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HissinOvi : MonoBehaviour
{
    public GameObject pelaaja;
    public GameObject kamera;
    public GameObject hissinNapit;
    private GameObject[] hissinNapitTaulukko;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Avaa()
    {
        hissinNapit.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
