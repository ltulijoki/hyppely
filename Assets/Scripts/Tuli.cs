using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuli : MonoBehaviour
{
    public float odotus;
    public Material nakymaton;
    public Material pieni;
    public Material iso;
    private int vaihe;
    private PolygonCollider2D pc;
    private MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PolygonCollider2D>();
        mr = GetComponent<MeshRenderer>();
        InvokeRepeating("Seuraava", 0, odotus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Seuraava()
    {
        vaihe++;
        if (vaihe > 3) vaihe = 0;

        if (vaihe == 0)
        {
            mr.material = nakymaton;
            pc.points = new Vector2[]{
                new Vector2(3, 0)
            };
        }
        if (vaihe == 1 || vaihe == 3)
        {
            mr.material = pieni;
            pc.points = new[]{
                new Vector2(0.3f, 0.2f), new Vector2(0.25f, 0.3f),
                new Vector2(0.05f, 0.2f), new Vector2(0, 0),
                new Vector2(0.04f, -0.14f), new Vector2(0.13f, -0.27f),
                new Vector2(0.3f, -0.22f), new Vector2(0.38f, -0.28f),
                new Vector2(0.4f, -0.2f), new Vector2(0.45f, -0.12f),
                new Vector2(0.5f, -0.15f), new Vector2(0.5f, 0.2f)
            };
        }
        if (vaihe == 2)
        {
            mr.material = iso;
            pc.points = new[]{
                new Vector2(0.06f, 0.3f), new Vector2(0, 0.5f),
                new Vector2(-0.5f, 0.23f), new Vector2(-0.5f, 0),
                new Vector2(-0.5f, -0.2f), new Vector2(-0.4f, -0.4f),
                new Vector2(0.25f, -0.5f), new Vector2(0.3f, -0.35f),
                new Vector2(0.5f, -0.3f), new Vector2(0.5f, 0.3f)
            };
        }
    }
}
