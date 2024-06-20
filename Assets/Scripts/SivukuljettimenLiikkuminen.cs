using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SivukuljettimenLiikkuminen : MonoBehaviour
{
    public float nopeus;
    public float vasen;
    public float oikea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * nopeus * Time.deltaTime);

        if (transform.position.x <= vasen || transform.position.x >= oikea)
            nopeus = Mathf.Abs(nopeus);
        if (transform.position.x >= oikea)
            nopeus *= -1;
    }
}
