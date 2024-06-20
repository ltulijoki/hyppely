using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class Bossi1Liikkuminen : MonoBehaviour
{
    public float nopeus;
    public Material normaaliMaterial;
    public Material kuollutMaterial;
    public Material vihainenMaterial;
    public GameObject bossinElamat;
    private int elamat = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D toinen)
    {
        GameObject toisenGameObject = toinen.gameObject;
        // seinä
        if (toisenGameObject.CompareTag("seina") || toisenGameObject.CompareTag("ovi"))
            nopeus *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * nopeus * Time.deltaTime);
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
            await Task.Delay(TimeSpan.FromSeconds(0.5f));
            mr.material = normaaliMaterial;
        }
    }
}
