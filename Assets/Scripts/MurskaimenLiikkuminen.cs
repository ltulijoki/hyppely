using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurskaimenLiikkuminen : MonoBehaviour
{
    public float nopeus;
    public float pysaytaAlas;
    public float pysaytaYlos;
    public bool nopeutaTippuessa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float kerro = 1;
        if (nopeus > 0 && nopeutaTippuessa)
            kerro = 5;
        transform.Translate(Vector3.down * nopeus * Time.deltaTime * kerro);

        if (transform.position.y - 4.5f <= pysaytaAlas || transform.position.y >= pysaytaYlos)
            nopeus = Mathf.Abs(nopeus);
        if (transform.position.y - 4.5f <= pysaytaAlas)
            nopeus *= -1;
    }
}
