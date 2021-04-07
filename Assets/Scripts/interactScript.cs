using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScript : MonoBehaviour
{
    public GameObject toggleRotation;
    public int counter;
    public GameObject stopMovingPlatforms;
    public GameObject[] platforms;
    public GameObject[] planets;
    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platforms");
        //planets = GameObject.FindGameObjectsWithTag("PlanetAttachable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            counter++;
        }
        // THIS IS WHERE THE INSPECTOR IS SEARCHING FOR THE CENTERPOS
        toggleRotation = GameObject.Find("CenterPosForRotation");
        if (toggleRotation != null)
        {
            if (Input.GetKeyDown("space") && counter % 2 == 0)
            {
                
                    toggleRotation.GetComponent<RotateScript>().enabled = true;
               
              
            }
            if (Input.GetKeyDown("space") && counter % 2 == 1)
            {
                
                    toggleRotation.GetComponent<RotateScript>().enabled = false;
                
            }
        }
        if (stopMovingPlatforms != null)
        {
            if (Input.GetKeyDown("space") && counter % 2 == 0)
            {
                foreach (GameObject stopMovingPlatforms in platforms)
                {
                    stopMovingPlatforms.GetComponent<MovingPlatform>().enabled = true;
                }
            }
            if (Input.GetKeyDown("space") && counter % 2 == 1)
            {
                foreach (GameObject stopMovingPlatforms in platforms)
                {
                    stopMovingPlatforms.GetComponent<MovingPlatform>().enabled = false;
                }
            }
        }
    }
}

