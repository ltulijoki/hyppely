using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaavapallonLiikkuminen : MonoBehaviour
{
    public float nopeus;
    public float maxKorkeus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * nopeus * Time.deltaTime);

        if (transform.position.y <= -5 || transform.position.y >= maxKorkeus)
            nopeus = Mathf.Abs(nopeus);
        if (transform.position.y >= maxKorkeus)
            nopeus *= -1;
    }
}
