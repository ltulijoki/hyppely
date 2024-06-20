using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viholliskone : MonoBehaviour
{
    public GameObject vihollinen;
    public GameObject pelaaja;
    public float odotus;
    public float vihollisenNopeus = -1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TeeVihollinen", 0, odotus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TeeVihollinen()
    {
        GameObject uusiVihollinen = Instantiate(
            vihollinen, new Vector3(transform.position.x, transform.position.y - 1.75f, 0),
            vihollinen.transform.rotation);
        Apufunktioita.AsetaVihollisenLiikkuminen(uusiVihollinen, pelaaja, vihollisenNopeus);
    }
}
