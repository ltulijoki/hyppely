using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeuraaPelaajanY : MonoBehaviour
{
    public GameObject pelaaja;
    public float alaraja;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > alaraja)
            transform.position = new Vector3(transform.position.x, pelaaja.transform.position.y, -10);
        if (transform.position.y < alaraja)
            transform.position = new Vector3(transform.position.x, alaraja, -10);
    }
}
