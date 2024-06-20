using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

public class Ovi : MonoBehaviour
{
    public Material lukittuOviMaterial;
    public Material oviMaterial;
    public Material oviAukiMaterial;
    public string kohde;
    public GameObject tuhottava;
    public bool annaMennaLapi;
    public bool odota;
    private MeshRenderer mr;
    private bool onLukittu;
    private bool auki;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        if (tuhottava != null) onLukittu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onLukittu && !auki)
            if (tuhottava == null) mr.material = oviMaterial;
            else mr.material = lukittuOviMaterial;
    }

    public async void Avaa()
    {
        if (annaMennaLapi)
            Destroy(GetComponent<BoxCollider2D>());
        if (kohde.EndsWith('1') || kohde.EndsWith('4'))
            TiedonTallentaja.olio.tallennettuTaso = kohde;
        auki = true;
        GetComponent<MeshRenderer>().material = oviAukiMaterial;
        if (odota) await Task.Delay(TimeSpan.FromSeconds(1));
        SceneManager.LoadScene(kohde);
    }
}
