using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spooky : MonoBehaviour
{
    public bool changed, temp;
    public Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        temp = false;
        changed = false;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible && !changed)
        {
            temp = true;
            Renderer rend = GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.blue);
        }
        else if (!renderer.isVisible && temp)
        {
            changed = true;
            Renderer rend = GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.red);

        }

        //print(renderer.isVisible);

    }
}
