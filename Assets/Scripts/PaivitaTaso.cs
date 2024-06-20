using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PaivitaTaso : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI teksti = GetComponent<TextMeshProUGUI>();
        teksti.text = SceneManager.GetActiveScene().name
            .Substring(0, 3).Replace('_', '-');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
