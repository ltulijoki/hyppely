using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiikkuvaViholliskone : MonoBehaviour
{
    public float nopeus;
    public GameObject kamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < kamera.transform.position.x)
            transform.Translate(Vector3.right * nopeus * Time.deltaTime);
    }
}
