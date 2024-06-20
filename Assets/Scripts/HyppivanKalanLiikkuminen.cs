using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyppivanKalanLiikkuminen : MonoBehaviour
{
    public float nopeus;
    public float hypynKorkeus;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * nopeus * Time.deltaTime);

        if (transform.position.y <= -8.5f)
            rb.velocity = Vector2.up * 5;

        if (transform.position.y >= hypynKorkeus)
            rb.velocity = Vector2.down * 5;
    }

    public void Osuma()
    {
        transform.position = new Vector3(transform.position.x, -8.5f, 0);
    }
}
