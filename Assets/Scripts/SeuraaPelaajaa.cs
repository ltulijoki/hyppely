using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeuraaPelaajaa : MonoBehaviour
{
    public GameObject pelaaja;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        string taso = SceneManager.GetActiveScene().name;
        if (taso == "3_3" && transform.position.x >= 40 && transform.position.y < 4)
            transform.Translate(Vector3.up * 2 * Time.deltaTime);
        if (taso == "7_1" && transform.position.x >= 10)
            transform.Translate(Vector3.up * Time.deltaTime);
        if (taso == "7_2MaanAlla" && transform.position.x >= 23)
            transform.Translate(Vector3.up * Time.deltaTime);
        if (taso == "7_4Ilmalaivassa" && transform.position.x >= 5)
            transform.Translate(Vector3.up * 0.75f * Time.deltaTime);
        float alaraja;
        if (taso == "7_3")
            alaraja = pelaaja.transform.position.y - 2.5f;
        else
            alaraja = -100;
        Apufunktioita.PysyRajojenSisalla(transform, pelaaja.transform.position.x, ala: alaraja);
    }
}
