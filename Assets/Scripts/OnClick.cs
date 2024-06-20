using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class OnClick : MonoBehaviour
{
    public GameObject tasolleTeksti;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        if (tasolleTeksti)
        {
            TextMeshProUGUI tmp = tasolleTeksti.GetComponent<TextMeshProUGUI>();
            tmp.text = "Palaa tasolle " + TiedonTallentaja.olio.tallennettuTaso[0] +
                "-" + TiedonTallentaja.olio.tallennettuTaso[2];
        }
    }

    public void PelaaUudestaan()
    {
        TiedonTallentaja.olio.Nollaa();
        TiedonTallentaja.olio.tallennettuTaso = "1_1";
        SceneManager.LoadScene("alku");
    }

    public void Tasolle()
    {
        TiedonTallentaja.olio.Nollaa();
        SceneManager.LoadScene(TiedonTallentaja.olio.tallennettuTaso);
    }

    public void Lopeta()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
