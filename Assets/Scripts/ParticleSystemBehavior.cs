using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemBehavior : MonoBehaviour
{
    public ParticleSystem pSystem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pSystem.isPlaying) pSystem.Play();
    }
}
