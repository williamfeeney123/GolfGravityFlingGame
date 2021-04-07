using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Allows the user to click on the square, drag, and release to fling
public class Fling : MonoBehaviour
{
    public float flingSpeed = 200f;
    public int counterForShots;
    public Text text;
    Rigidbody2D rb;
    Vector2 mouseDownPos;
    Vector2 mouseUpPos;

    Vector3 startPos;
    Vector3 endPos;
    Camera camera;
    LineRenderer lr;
   

    Vector3 camOffset = new Vector3(0, 0, 10);

    [SerializeField] AnimationCurve ac;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    void OnMouseUp()
    {


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lr == null)
            {
                lr = gameObject.AddComponent<LineRenderer>();

            }
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
            lr.SetPosition(1, endPos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
            // get mouse position in world coordinates
            mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // difference vector
            Vector2 diff = (Vector2)startPos - (Vector2)endPos;
            // add that force with speed
            rb.AddForce(diff * flingSpeed);

            counterForShots++;

            //text.text = "Shots: " + counterForShots;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.tag == "DEATHBOX")
        {
            Debug.Log("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
