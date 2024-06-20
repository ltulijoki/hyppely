using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class VihollisenLiikkuminen : MonoBehaviour
{
    public GameObject pelaaja;
    public float nopeus;
    public Material vihollinenKuollutMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < pelaaja.transform.position.x)
            transform.Translate(Vector3.right * nopeus * Time.deltaTime);
        else
            transform.Translate(Vector3.left * nopeus * Time.deltaTime);
    }

    public async void Osuma()
    {
        GetComponent<MeshRenderer>().material = vihollinenKuollutMaterial;
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.offset = new Vector2(0, 0.34f);
        bc.size = new Vector2(1, 0.3f);
        await Task.Delay(TimeSpan.FromSeconds(0.5f));
        Destroy(gameObject);
    }
}
