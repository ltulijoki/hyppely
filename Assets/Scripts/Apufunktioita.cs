using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apufunktioita : MonoBehaviour
{
    public static void PysyRajojenSisalla(Transform transform, float vasen,
        float oikea = 100, float yla = 100, float ala = -100)
    {
        if (transform.position.x < vasen)
            transform.position = new Vector3(vasen, transform.position.y, transform.position.z);

        if (transform.position.x > oikea)
            transform.position = new Vector3(oikea, transform.position.y, transform.position.z);

        if (transform.position.y < ala)
            transform.position = new Vector3(transform.position.x, ala, transform.position.z);

        if (transform.position.y > yla)
            transform.position = new Vector3(transform.position.x, yla, transform.position.z);
    }

    public static void AsetaVihollisenLiikkuminen(GameObject vihollinen, GameObject pelaaja, float nopeus)
    {
        VihollisenLiikkuminen vl = vihollinen.GetComponent<VihollisenLiikkuminen>();
        if (vl != null)
        {
            vl.pelaaja = pelaaja;
            if (nopeus != -1) vl.nopeus = nopeus;
        }
        KalanLiikkuminen kl = vihollinen.GetComponent<KalanLiikkuminen>();
        if (kl != null)
        {
            kl.pelaaja = pelaaja;
            if (nopeus != -1) kl.nopeus = nopeus;
        }
    }
}
