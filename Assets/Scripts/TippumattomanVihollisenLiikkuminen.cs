using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TippumattomanVihollisenLiikkuminen : MonoBehaviour
{
    public GameObject pelaaja;
    public float nopeus;
    public float vasenRaja;
    public float oikeaRaja;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * nopeus * Time.deltaTime);
        if (transform.position.x < vasenRaja && nopeus < 0) nopeus *= -1;
        if (transform.position.x > oikeaRaja && nopeus > 0) nopeus *= -1;
    }
}
