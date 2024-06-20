using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porkkanalaatikko : MonoBehaviour
{
    public GameObject porkkana;
    public Material tyhjaMaterial;
    private bool onTyhja;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OtaPorkkana()
    {
        if (onTyhja) return;
        Instantiate(
            porkkana, new Vector3(transform.position.x, transform.position.y + 1, 0),
            porkkana.transform.rotation);
        onTyhja = true;
        GetComponent<MeshRenderer>().material = tyhjaMaterial;
    }
}
