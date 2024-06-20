using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TippuvaAlusta : MonoBehaviour
{
    public GameObject pelaaja;
    public float nopeus;
    private PolygonCollider2D pelaajanCollider;
    private BoxCollider2D omaCollider;

    // Start is called before the first frame update
    void Start()
    {
        pelaajanCollider = pelaaja.GetComponent<PolygonCollider2D>();
        omaCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (omaCollider.IsTouching(pelaajanCollider) &&
            pelaaja.GetComponent<PelaajanLiikkuminen>().OnkoPaalla(gameObject))
            transform.Translate(Vector3.down * nopeus * Time.deltaTime);
    }
}
