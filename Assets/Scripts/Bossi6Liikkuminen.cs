using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class Bossi6Liikkuminen : MonoBehaviour
{
    public float odotus;
    public float ammuksenNopeus;
    public GameObject jaatynyt;
    public GameObject piikkipallo;
    public GameObject vihollinenEiSaaOsua;
    public Material normaaliMaterial;
    public Material kuollutMaterial;
    public Material vihainenMaterial;
    public Material mustaLaatikkoMaterial;
    public GameObject[] piikkipallot;
    public GameObject bossinElamat;
    private int elamat = 3;
    private int panoksiaAmmuttu = 0;
    private JaatyneenAmmuksenLiikkuminen al;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ammu", 0, odotus);
    }

    async void OnCollisionEnter2D(Collision2D toinen)
    {
        if (toinen.gameObject.CompareTag("vihollinenEiSaaOsua"))
        {
            Destroy(toinen.gameObject);
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
                foreach (GameObject piikkipallo in piikkipallot)
                {
                    piikkipallo.GetComponent<MeshRenderer>().material = mustaLaatikkoMaterial;
                    piikkipallo.tag = "laatikko";
                }
                Destroy(gameObject);
            }
            else
            {
                mr.material = vihainenMaterial;
                await Task.Delay(TimeSpan.FromSeconds(0.5f));
                mr.material = normaaliMaterial;
                panoksiaAmmuttu = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Apufunktioita.PysyRajojenSisalla(transform, 7, 7, -2, -2);
    }

    void Ammu()
    {
        if (panoksiaAmmuttu < 3)
        {
            GameObject ammus = Instantiate(
                piikkipallo, new Vector3(transform.position.x - 1.5f, transform.position.y - 1.5f, 0),
                piikkipallo.transform.rotation
            );
            AmmuksenLiikkuminen al = ammus.AddComponent<AmmuksenLiikkuminen>();
            al.nopeus = ammuksenNopeus;
        }
        else if (panoksiaAmmuttu == 3 || (al != null && al.reunanYli))
        {
            GameObject ammus = Instantiate(
                jaatynyt, new Vector3(transform.position.x - 1.5f, transform.position.y - 1.5f, 0),
                jaatynyt.transform.rotation
            );
            Sula sula = ammus.GetComponent<Sula>();
            sula.muutu = vihollinenEiSaaOsua;
            sula.pelaaja = gameObject;
            al = ammus.AddComponent<JaatyneenAmmuksenLiikkuminen>();
            al.nopeus = ammuksenNopeus;
        }
        panoksiaAmmuttu++;
    }

    class AmmuksenLiikkuminen : MonoBehaviour
    {
        public float nopeus;

        void Update()
        {
            transform.position += Vector3.left * nopeus * Time.deltaTime;
        }
    }

    class JaatyneenAmmuksenLiikkuminen : MonoBehaviour
    {
        public float nopeus;
        public bool reunanYli = false;
        private bool liiku = true;

        void Update()
        {
            if (liiku)
            {
                transform.position += Vector3.left * nopeus * Time.deltaTime;
                if (transform.position.x <= -3.5f)
                    liiku = false;
            }
            if (transform.position.y < -6)
            {
                reunanYli = true;
            }
        }
    }
}
