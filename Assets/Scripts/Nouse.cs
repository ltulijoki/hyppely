using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nouse : MonoBehaviour
{
    public float nopeus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * nopeus / 2 * Time.deltaTime);
        transform.localScale = new Vector3(transform.localScale.x,
            transform.localScale.y + nopeus * Time.deltaTime, 1);
    }
}
