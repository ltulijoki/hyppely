using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HissinNappi : MonoBehaviour
{
    public GameObject pelaaja;
    public GameObject kamera;
    public Vector3 pelaajanPaikka;
    public Vector3 kameranPaikka;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mene()
    {
        pelaaja.transform.position = pelaajanPaikka;
        kamera.transform.position = kameranPaikka;
        transform.parent.gameObject.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        Transform hissinNapit = transform.parent;
        for (int i = 0; i < hissinNapit.childCount; i++)
        {
            hissinNapit.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
        }
        GetComponent<Image>().color = Color.green;
    }
}
