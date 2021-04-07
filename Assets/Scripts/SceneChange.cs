using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
 
    public static int numScene = 2;
    //Any Collider2D component will call this function on
    //any attached scripts when the collider enters a collision with another collider.
    //The gameobject must also have a RigidBody2D attached.

    public void ButtonPress()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void ButtonTitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonTitle()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonTitle2()
    {
        SceneManager.LoadScene(22);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            numScene++;
            SceneManager.LoadScene(numScene);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            numScene--;
            SceneManager.LoadScene(numScene);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag == "Finish")
        {
         
            SceneManager.LoadScene(numScene);
            numScene++;
        }



        if (collision.collider.tag == "BadBlackHole")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //Swap Scene Dumps

    public void ZeroZero()
    {
        
        SceneManager.LoadScene(1);
    }
    public void ZeroOne()
    {
        numScene = 3;
        SceneManager.LoadScene(2);
    }
    public void ZeroTwo()
    {
        numScene = 4;
        SceneManager.LoadScene(3);
    }
    public void ZeroThree()
    {
        numScene = 4;
        SceneManager.LoadScene(4);
    }
    public void ZeroFour()
    {
        numScene = 5;
        SceneManager.LoadScene(5);
    }
    public void OneZero()
    {
        numScene = 6;
        SceneManager.LoadScene(6);
    }
    public void OneOne()
    {
        numScene = 7;
        SceneManager.LoadScene(7);
      
    }
    public void OneTwo()
    {
        numScene = 8;
        SceneManager.LoadScene(8);
    }
    public void OneThree()
    {
        numScene = 9;
        SceneManager.LoadScene(9);
    }
    public void OneFour()
    {
        numScene = 10;
        SceneManager.LoadScene(10);
    }
    public void TwoZero()
    {
        numScene = 11;
        SceneManager.LoadScene(11);
    }
    public void TwoOne()
    {
        numScene = 12;
        SceneManager.LoadScene(12);
    }
    public void TwoTwo()
    {
        numScene = 13;
        SceneManager.LoadScene(13);
    }
    public void TwoThree()
    {
        numScene = 14;
        SceneManager.LoadScene(14);
    }
    public void ThreeZero()
    {
        numScene = 15;
        SceneManager.LoadScene(15);
    }
    public void ThreeOne()
    {
        numScene = 16;
        SceneManager.LoadScene(16);
    }
    public void ThreeTwo()
    {
        numScene = 17;
        SceneManager.LoadScene(17);
    }
    public void FiveZero()
    {
        numScene = 18;
        SceneManager.LoadScene(18);
    }
    public void SixZero()
    {
        numScene = 19;
        SceneManager.LoadScene(19);
    }
    public void SevenZero()
    {
        numScene = 20;
        SceneManager.LoadScene(20);
    }
    public void EightZero()
    {
        numScene = 21;
        SceneManager.LoadScene(21);
    }
}
