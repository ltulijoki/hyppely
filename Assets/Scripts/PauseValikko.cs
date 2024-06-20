using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseValikko : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        gameObject.SetActive(true);
    }

    public void Jatka()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }

    public void Alusta()
    {
        Time.timeScale = 1;
        TiedonTallentaja.olio.Nollaa();
        TiedonTallentaja.olio.tallennettuTaso = "1_1";
        SceneManager.LoadScene("alku");
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
