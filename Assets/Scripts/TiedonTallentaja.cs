using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiedonTallentaja : MonoBehaviour
{
    public static TiedonTallentaja olio;
    public bool pelaajallaOnPorkkana;
    public string tallennettuTaso = "1_1";

    void Awake()
    {
        if (olio != null)
        {
            Destroy(gameObject);
            return;
        }
        olio = this;
        DontDestroyOnLoad(gameObject);
        Nollaa();
    }

    public void Nollaa()
    {
        pelaajallaOnPorkkana = false;
    }
}
