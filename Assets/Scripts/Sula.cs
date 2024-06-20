using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sula : MonoBehaviour
{
    public GameObject muutu;
    public GameObject pelaaja;
    public float vihollisenNopeus = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D toinen)
    {
        if (toinen.gameObject.CompareTag("vihollinenEiSaaOsua"))
        {
            GameObject uusi = Instantiate(muutu, transform.position, muutu.transform.rotation);
            Apufunktioita.AsetaVihollisenLiikkuminen(uusi, pelaaja, vihollisenNopeus);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
