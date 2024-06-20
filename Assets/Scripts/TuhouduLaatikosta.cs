using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuhouduLaatikosta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D toinen)
    {
        if (toinen.gameObject.CompareTag("laatikko") || toinen.gameObject.CompareTag("jaa"))
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
