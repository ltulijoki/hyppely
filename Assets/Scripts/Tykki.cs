using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tykki : MonoBehaviour
{
    public GameObject tykinkuula;
    public float odotus;
    public bool ammuVasemmalle;
    public bool ammuOikealle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ammu", 0, odotus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ammu()
    {
        if (ammuVasemmalle)
            Instantiate(
                tykinkuula, new Vector3(transform.position.x - 1.5f, transform.position.y, 0),
                Quaternion.Euler(new Vector3(0, 0, 180)));
        if (ammuOikealle)
            Instantiate(
                tykinkuula, new Vector3(transform.position.x + 1.5f, transform.position.y, 0),
                Quaternion.Euler(Vector3.zero));
    }
}
