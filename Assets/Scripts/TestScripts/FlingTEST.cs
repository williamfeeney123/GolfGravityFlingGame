using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Allows the user to click on the square, drag, and release to fling
public class FlingTEST : MonoBehaviour
{
    public float flingSpeed = 200f;
    public int counterForShots;
    public Text text;
    public int MaxNumOfShots;
    public GameObject hole;
    Rigidbody2D rb;
    Vector2 mouseDownPos;
    Vector2 mouseUpPos;
    public Vector2 diff;
    Vector3 startPos;
    Vector3 endPos;
    Camera camera;
    LineRenderer lr;
    TrailRenderer tr;

    public Color startColor = Color.green;
    public Color endColor = Color.green;

    public bool isGrounded = false;

    Vector3 camOffset = new Vector3(0, 0, 10);

    [SerializeField] AnimationCurve ac;


    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


public void Play()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        lr = GetComponent<LineRenderer>();
        tr = GetComponent<TrailRenderer>();

    }

    void OnMouseUp()
    {


    }

    void Update()
    {

        if (counterForShots > MaxNumOfShots)
        {
            StartCoroutine(StartCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartButton();
        }
     

        text.text = "Shots: " + counterForShots + " / " + MaxNumOfShots;
        if (isGrounded == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lr == null)
                {
                    //lr = gameObject.AddComponent<LineRenderer>();
                }
                tr.Clear();
                lr.enabled = true;
                lr.positionCount = 2;
                startPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
                lr.SetPosition(0, startPos);
                lr.useWorldSpace = true;
                lr.widthCurve = ac;
                lr.numCapVertices = 10;
                
               
            }
            if (Input.GetMouseButton(0))
            {
                
                endPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
                // Debug.Log(endPos.x);
                //Debug.Log(Vector2.Distance(startPos, endPos));

                float newVarforColor = (((Vector2.Distance(startPos, endPos) - 0) * (1 - 0)) / (16 - 0)) + 0;
                float newVar = (((Vector2.Distance(startPos, endPos) - 0) * (0-1)) / (16 - 0)) + 1;

                lr.startColor = new Color(newVarforColor, newVar, 0);
                lr.endColor = new Color(newVarforColor, newVar, 0);

                if (Vector2.Distance(startPos, endPos) > Mathf.Abs(8))
                {
                 
                    lr.startColor = new Color(newVarforColor,newVar,0);
                    lr.endColor = new Color(newVarforColor,newVar,0);

                }

               


                lr.SetPosition(1, endPos);
            }

                if (Input.GetMouseButtonUp(0))
            {
                lr.enabled = false;
                // get mouse position in world coordinates
                mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // difference vector
                diff = (Vector2)startPos - (Vector2)endPos;
              
                // add that force with speed
                rb.AddForce(diff * flingSpeed);
                //Debug.Log(diff.x);
             

                if (diff.x > 0 || diff.x < 0)
                {
                    counterForShots++;

                    text.text = "Shots: " + counterForShots + " / " + MaxNumOfShots;
                    isGrounded = false;
                }

             
                

            }

        }
        //VELOCITY MAX TEST??
        if(rb.velocity.x >= 25)
        {
            rb.velocity = new Vector2(25, rb.velocity.y);
        }
        if (rb.velocity.x <= -25)
        {
            rb.velocity = new Vector2(-25, rb.velocity.y);
        }
        if (rb.velocity.y >= 25)
        {
            rb.velocity = new Vector2(rb.velocity.x, 25);
        }
        if (rb.velocity.y <= -25)
        {
            rb.velocity = new Vector2(rb.velocity.x, -25);
        }


        if (hole != null)
        {
            if (this.gameObject.transform.IsChildOf(hole.transform))
            {
                isGrounded = true;
            }
        }
        

        //restart button


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log(isGrounded);

        if (collision.collider.gameObject.tag == "DEATHBOX")
        {
            Debug.Log("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlanetAttachable")
        {
            hole = collision.gameObject;
            this.transform.SetParent(collision.gameObject.transform);

            Debug.Log("pog");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlanetAttachable")
        {
            hole = null;
           isGrounded = false;
            this.transform.parent = null;
            Debug.Log("notpog");
        }
    }

    IEnumerator StartCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
