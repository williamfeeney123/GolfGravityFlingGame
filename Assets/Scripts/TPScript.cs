using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScript : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}
