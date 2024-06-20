using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TykinkuulanLiikkuminen : MonoBehaviour
{
    public float nopeus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * nopeus * Time.deltaTime);
    }

    public void Osuma()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
    }
}
