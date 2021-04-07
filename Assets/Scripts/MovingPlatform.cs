using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //My magnum opus. This class is attached to a platform object which is used in conjunction
    //with an empty gameobject to create a cyclically moving object.

    //Speed at which platform moves. movingRight indicates whether the platform is moving toward its
    //target. Once false, it returns to its initial position.
    public float speed;
    public bool movingRight;

    //The starting position of the platform and the ending position. Both are informed by
    //gameobjects-- with the former being fed a location by the platform itself and the
    //latter being filled in by the empty gameobject.
    private Vector3 startingPos;
    public Transform moveToPos;

    void Start()
    {
        //Initializing
        startingPos = transform.position;
    }

    void Update()
    {
        //These two conditionals make the platform move left and right through a bool.
        if (transform.position == moveToPos.position)
        {
            movingRight = false;
        }

        else if (transform.position == startingPos)
        {
            movingRight = true;
        }

        //Uses the MoveTowards functionality to move toward the specified target-- the starting
        //position and the ending position at a rate of speed * Time.deltaTime.
        if (movingRight == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPos, (speed * Time.deltaTime));
        }
        else if (movingRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, (speed * Time.deltaTime));
        }

    }
}