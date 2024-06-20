using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class Bossi2Liikkuminen : MonoBehaviour
{
    public float odotus;
    public float ammuksenNopeus;
    public GameObject laavapallo;
    public GameObject pelaaja;
    public Material normaaliMaterial;
    public Material kuollutMaterial;
    public Material vihainenMaterial;
    public GameObject bossinElamat;
    private int elamat = 3;
    private bool vihainen;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ammu", 0, odotus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void Osuma()
    {
        elamat--;
        bossinElamat.GetComponent<PaivitaBossinElama>().Paivita(elamat);
        MeshRenderer mr = GetComponent<MeshRenderer>();
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
            vihainen = true;
            await Task.Delay(TimeSpan.FromSeconds(0.5f));
            vihainen = false;
            mr.material = normaaliMaterial;
        }
    }
    
    void Ammu()
    {
        if (vihainen) return;
        GameObject ammus = Instantiate(
            laavapallo, new Vector3(transform.position.x - 1.75f, transform.position.y, 0),
            laavapallo.transform.rotation
        );
        Destroy(ammus.GetComponent<LaavapallonLiikkuminen>());
        AmmuksenLiikkuminen al = ammus.AddComponent<AmmuksenLiikkuminen>();
        al.nopeus = ammuksenNopeus;
        al.pelaaja = pelaaja;
    }

    class AmmuksenLiikkuminen: MonoBehaviour
    {
        public float nopeus;
        public GameObject pelaaja;

        private Vector3 pelaajanSijainti;

        void Start()
        {
            pelaajanSijainti = (pelaaja.transform.position - transform.position).normalized;
        }

        void Update()
        {
            transform.position += pelaajanSijainti * nopeus * Time.deltaTime;
        }
    }
}
