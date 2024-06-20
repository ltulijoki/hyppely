using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuljettimenLiikkuminen : MonoBehaviour
{
    public float nopeus;
    public float ala;
    public float yla;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * nopeus * Time.deltaTime);

        if (transform.position.y <= ala || transform.position.y >= yla)
            nopeus = Mathf.Abs(nopeus);
        if (transform.position.y >= yla)
            nopeus *= -1;
    }
}
