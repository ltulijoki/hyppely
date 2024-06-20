using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumikone : MonoBehaviour
{
    public GameObject lumi;
    public float vasen;
    public float oikea;
    public float odotus;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Lisaa", 0, odotus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Lisaa()
    {
        Instantiate(lumi, new Vector3(Random.Range(vasen, oikea), 5.5f, 0), lumi.transform.rotation);
    }
}
