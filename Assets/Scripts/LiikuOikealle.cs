using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiikuOikealle : MonoBehaviour
{
    public float nopeus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Vector3.right * nopeus * Time.deltaTime);
    }
}
