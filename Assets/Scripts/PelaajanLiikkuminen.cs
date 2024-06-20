using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PelaajanLiikkuminen : MonoBehaviour
{
    public float nopeus;
    public float hypynKorkeus;
    public bool onVedessa;
    public bool salliYlosMeneminen;
    public Material pelaajallaEiPorkkaanaaMaterial;
    public Material pelaajallaPorkkanaMaterial;
    public GameObject kamera;
    public string[] pystyyHypataPaalta;
    private Rigidbody2D rb;
    private MeshRenderer mr;
    private bool onMaassa = true;
    private bool onJaalla;
    private bool eiMennytOvesta = true;
    private Vector3 aloitus;
    private float kameranAlkuY;
    private GameObject pause;
#if UNITY_EDITOR
    public string POISTASIIRRYTASOLLE; // POISTA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public bool POISTAONPORKKANA;      // POISTA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public bool POISTAEIVOIKUOLLA;     // POISTA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
#endif

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mr = GetComponent<MeshRenderer>();
        aloitus = transform.position;
        kameranAlkuY = kamera.transform.position.y;
        Cursor.visible = false;
        Time.timeScale = 1;
        pause = GameObject.Find("pause");
        pause.SetActive(false);
#if UNITY_EDITOR
        if (POISTAONPORKKANA) TiedonTallentaja.olio.pelaajallaOnPorkkana = true;   //POISTA!!!!!!!!!!!!!!!!!!!!!!!
        if (POISTASIIRRYTASOLLE != "") SceneManager.LoadScene(POISTASIIRRYTASOLLE);//POISTA!!!!!!!!!!!!!!!!!!!!!!!
#endif
    }

    void OnCollisionEnter2D(Collision2D toinen)
    {
        GameObject toisenGameObject = toinen.gameObject;

        foreach (string tag in pystyyHypataPaalta)
            if (toisenGameObject.CompareTag(tag) && OnkoPaalla(toisenGameObject))
                onMaassa = true;

        if (toisenGameObject.CompareTag("porkkanalaatikko") && OnkoAlla(toisenGameObject))
            toisenGameObject.GetComponent<Porkkanalaatikko>().OtaPorkkana();

        if (toisenGameObject.CompareTag("porkkana"))
        {
            TiedonTallentaja.olio.pelaajallaOnPorkkana = true;
            Destroy(toisenGameObject);
        }

        if (toisenGameObject.CompareTag("vihollinen") && eiMennytOvesta)
        {
            if (OnkoPaalla(toisenGameObject))
                toisenGameObject.GetComponent<VihollisenLiikkuminen>().Osuma();
            else
                Osuma();
        }

        if (toisenGameObject.CompareTag("tykinkuula") && eiMennytOvesta)
        {
            if (OnkoPaalla(toisenGameObject))
                toisenGameObject.GetComponent<TykinkuulanLiikkuminen>().Osuma();
            else
                Osuma();
        }

        if (toisenGameObject.CompareTag("hyppivaKala") && eiMennytOvesta)
        {
            if (OnkoPaalla(toisenGameObject))
                toisenGameObject.GetComponent<HyppivanKalanLiikkuminen>().Osuma();
            else
                Osuma();
        }

        if ((toisenGameObject.CompareTag("vihollinenEiSaaOsua") ||
            toisenGameObject.CompareTag("vihollinenEiSaaOsuaEiSulata")) && eiMennytOvesta)
            Osuma();

        if (toisenGameObject.CompareTag("murskain") && OnkoAlla(toisenGameObject) && eiMennytOvesta)
            Osuma();
        if (toisenGameObject.CompareTag("murskainTeraYlhaalla") && OnkoPaalla(toisenGameObject) && eiMennytOvesta)
            Osuma();

        if (toisenGameObject.CompareTag("ovi") && toisenGameObject.GetComponent<Ovi>().tuhottava == null)
        {
            eiMennytOvesta = false;
            GetComponent<Renderer>().enabled = false;
            toisenGameObject.GetComponent<Ovi>().Avaa();
        }

        if (toisenGameObject.CompareTag("hissinOvi"))
        {
            Input.ResetInputAxes();
            toisenGameObject.GetComponent<HissinOvi>().Avaa();
        }

        if (toisenGameObject.CompareTag("jaa") && OnkoPaalla(toisenGameObject))
            onJaalla = true;

        if (toisenGameObject.CompareTag("bossi1") && eiMennytOvesta)
        {
            if (OnkoPaalla(toisenGameObject))
            {
                toisenGameObject.GetComponent<Bossi1Liikkuminen>().Osuma();
                transform.position = new Vector3(0, 1.6f, 0);
            }
            else
                Osuma();
        }

        if (toisenGameObject.CompareTag("bossi2") && eiMennytOvesta)
        {
            if (OnkoPaalla(toisenGameObject))
            {
                toisenGameObject.GetComponent<Bossi2Liikkuminen>().Osuma();
                transform.position = new Vector3(-8.4f, -3.4f, 0);
            }
            else
                Osuma();
        }

        if (toisenGameObject.CompareTag("bossi3") && eiMennytOvesta)
        {
            if (OnkoPaalla(toisenGameObject))
            {
                toisenGameObject.GetComponent<Bossi3Liikkuminen>().Osuma();
                transform.position = new Vector3(-8.4f, -3.4f, 0);
            }
            else
                Osuma();
        }

        if (toisenGameObject.CompareTag("bossi4") && eiMennytOvesta)
        {
            if (OnkoPaalla(toisenGameObject))
            {
                toisenGameObject.GetComponent<Bossi4Liikkuminen>().Osuma();
                transform.position = new Vector3(-8.4f, 1.6f, 0);
            }
            else
                Osuma();
        }

        if (toisenGameObject.CompareTag("bossi5") && eiMennytOvesta)
        {
            if (OnkoPaalla(toisenGameObject))
            {
                toisenGameObject.GetComponent<Bossi5Liikkuminen>().Osuma();
                transform.position = new Vector3(-8.4f, -3.4f, 0);
            }
            else
                Osuma();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Apufunktioita.PysyRajojenSisalla(transform,
            kamera.transform.position.x - 8.5f, kamera.transform.position.x + 8.5f,
            salliYlosMeneminen ? 100 : 4.5f);

        if (TiedonTallentaja.olio.pelaajallaOnPorkkana)
            mr.material = pelaajallaPorkkanaMaterial;
        else
            mr.material = pelaajallaEiPorkkaanaaMaterial;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            if (Time.timeScale > 0)
                pause.GetComponent<PauseValikko>().Pause();
            else
                pause.GetComponent<PauseValikko>().Jatka();

        float x = Input.GetAxis("Horizontal") * nopeus * Time.deltaTime;
        if (onJaalla)
            x += nopeus / 5 * Time.deltaTime;
        transform.Translate(Vector3.right * x);

        if (onMaassa && !onVedessa)
        {
            rb.AddForce(Vector2.up * hypynKorkeus * Input.GetAxis("Jump"), ForceMode2D.Force);
            if (Input.GetAxisRaw("Jump") == 1)
            {
                onMaassa = false;
                onJaalla = false;
            }
        }
        if (onVedessa)
            rb.AddForce(Vector2.up * hypynKorkeus / 50 * Input.GetAxis("Jump"), ForceMode2D.Force);

#if UNITY_EDITOR
        if (POISTAEIVOIKUOLLA) return;
#endif
        float raja;
        if (SceneManager.GetActiveScene().name.StartsWith("7"))
            raja = kamera.transform.position.y - 4.5f;
        else raja = -4.5f;
        if (transform.position.y < raja && eiMennytOvesta)
            SceneManager.LoadScene("gameover");
    }

    public void Osuma()
    {
#if UNITY_EDITOR
        if (POISTAEIVOIKUOLLA) return;
#endif
        if (TiedonTallentaja.olio.pelaajallaOnPorkkana)
        {
            TiedonTallentaja.olio.pelaajallaOnPorkkana = false;
            transform.position = aloitus;
            kamera.transform.position = new Vector3(0, kameranAlkuY, -10);
        }
        else
            SceneManager.LoadScene("gameover");
    }

    public bool OnkoPaalla(GameObject toinen)
    {
        return Mathf.Abs((transform.position.y - 0.5f * transform.lossyScale.y) -
            (toinen.transform.position.y + 0.5f * toinen.transform.lossyScale.y)) <= 0.2f;
    }

    public bool OnkoAlla(GameObject toinen)
    {
        return Mathf.Abs((toinen.transform.position.y - 0.5f * toinen.transform.lossyScale.y) -
            (transform.position.y + 0.5f * transform.lossyScale.y)) <= 0.2f;
    }
}
