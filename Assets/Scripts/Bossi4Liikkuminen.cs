using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class Bossi4Liikkuminen : MonoBehaviour
{
    public float odotus;
    public float nopeus;
    public float vedenNopeus;
    public GameObject pelaaja;
    public GameObject vesi;
    public Material normaaliMaterial;
    public Material kuollutMaterial;
    public Material vihainenMaterial;
    public GameObject bossinElamat;
    private Vector3 kohde;
    private float tila;
    private int elamat = 3;
    private PelaajanLiikkuminen pl;
    private Rigidbody2D pr;

    // Start is called before the first frame update
    void Start()
    {
        pl = pelaaja.GetComponent<PelaajanLiikkuminen>();
        pr = pelaaja.GetComponent<Rigidbody2D>();
        InvokeRepeating("Seuraava", odotus, odotus);
    }

    // Update is called once per frame
    void Update()
    {
        if (tila == 0)
        {
            Vector3 erotus = pelaaja.transform.position - transform.position;
            if (erotus.sqrMagnitude > 25)
                kohde = erotus.normalized;
            
            transform.position += kohde * nopeus * Time.deltaTime;
        }
        if (tila == 1)
        {
            pl.onVedessa = false;
            pr.gravityScale = 1;

            if (vesi.transform.position.y > -9)
                vesi.transform.Translate(Vector3.down * vedenNopeus * Time.deltaTime);
            if (transform.position.y > -2.75f)
                transform.Translate(Vector3.down * nopeus * Time.deltaTime);
            if (vesi.transform.position.y <= -9 && transform.position.y <= -2.75f)
                tila = 2;
        }
        if (tila == 3)
        {
            pl.onVedessa = true;
            pr.gravityScale = 0.25f;

            vesi.transform.Translate(Vector3.up * vedenNopeus * Time.deltaTime);
            if (vesi.transform.position.y >= 0)
                tila = 0;
        }
    }

    public async void Osuma()
    {
        if (tila == 2)
        {
            elamat--;
            bossinElamat.GetComponent<PaivitaBossinElama>().Paivita(elamat);
            MeshRenderer mr = GetComponent<MeshRenderer>();
            if (elamat <= 0)
            {
                mr.material = kuollutMaterial;
                PolygonCollider2D pc = GetComponent<PolygonCollider2D>();
                pc.points = new[]{
                    new Vector2(0.5f, -0.2f), new Vector2(-0.5f, -0.2f),
                    new Vector2(-0.5f, -0.5f), new Vector2(0.5f, -0.5f)
                };
                await Task.Delay(TimeSpan.FromSeconds(0.5f));
                Destroy(gameObject);
            }
            else
            {
                mr.material = vihainenMaterial;
                await Task.Delay(TimeSpan.FromSeconds(0.5f));
                mr.material = normaaliMaterial;
                tila = 3;
            }
        }
        else
            pl.Osuma();
    }

    void Seuraava()
    {
        if (tila % 2 == 0)
            tila++;
    }
}
