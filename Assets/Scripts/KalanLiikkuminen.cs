using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalanLiikkuminen : MonoBehaviour
{
    public GameObject pelaaja;
    public float nopeus;
    private Vector3 kohde;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 erotus = pelaaja.transform.position - transform.position;
        if (erotus.sqrMagnitude > 25)
            kohde = erotus.normalized;
        
        transform.position += kohde * nopeus * Time.deltaTime;
    }
}
