using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class Bossi3Liikkuminen : MonoBehaviour
{
    public float odotus;
    public float nopeus;
    public float tippumisnopeus;
    public GameObject pelaaja;
    public GameObject vasenLaatikko;
    public GameObject oikeaLaatikko;
    public Material normaaliMaterial;
    public Material kuollutMaterial;
    public Material vihainenMaterial;
    public GameObject bossinElamat;
    private int elamat = 3;
    private int suunta;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Tipu", odotus, odotus);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * suunta * tippumisnopeus * Time.deltaTime);

        if (transform.position.y >= 3)
        {
            if (suunta < 0)
                suunta = 0;
            if (suunta == 0)
            {
                nopeus = MathF.Abs(nopeus);
                if (pelaaja.transform.position.x < transform.position.x)
                    nopeus *= -1;
                transform.Translate(Vector3.right * nopeus * Time.deltaTime);

                Apufunktioita.PysyRajojenSisalla(transform, -6.75f, 6.75f, 3);
            }
        }

        if (transform.position.y <= -2 && suunta == 1)
        {
            suunta = 0;
            vasenLaatikko.transform.position = new Vector3(transform.position.x - 2.5f, -1.5f, 0);
            oikeaLaatikko.transform.position = new Vector3(transform.position.x + 2.5f, -1.5f, 0);
        }
    }

    public async void Osuma()
    {
        elamat--;
        bossinElamat.GetComponent<PaivitaBossinElama>().Paivita(elamat);
        MeshRenderer mr = GetComponent<MeshRenderer>();
        vasenLaatikko.transform.position = new Vector3(-10, 0, 0);
        oikeaLaatikko.transform.position = new Vector3(-10, 0, 0);
        if (elamat <= 0)
        {
            mr.material = kuollutMaterial;
            PolygonCollider2D pc = GetComponent<PolygonCollider2D>();
            pc.points = new[]{
                new Vector2(0, -0.15f), new Vector2(-0.4f, -0.18f),
                new Vector2(-0.5f, -0.5f), new Vector2(0.5f, -0.5f),
                new Vector2(0.36f, -0.15f)
            };
            await Task.Delay(TimeSpan.FromSeconds(0.5f));
            Destroy(gameObject);
        }
        else
        {
            mr.material = vihainenMaterial;
            await Task.Delay(TimeSpan.FromSeconds(0.5f));
            mr.material = normaaliMaterial;
            suunta = -1;
        }
    }
    
    void Tipu()
    {
        if (suunta == 0)
            suunta = 1;
    }
}
