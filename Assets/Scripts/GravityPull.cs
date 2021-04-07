using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPull : MonoBehaviour
{
    public Transform player;
   
    Rigidbody2D playerBody;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    Vector2 pullForce;
    // Start is called before the first frame update
    void Start()
    {
       
        playerBody = player.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceToPlayer <= influenceRange)
        {
            pullForce = (transform.position - player.position).normalized / distanceToPlayer * intensity;
            playerBody.AddForce(pullForce, ForceMode2D.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, influenceRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, influenceRange/2);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, influenceRange / 6);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerBody.velocity.x > 0 && playerBody.velocity.y > 0)
        {
            Debug.Log("PLAYER HIT THE BOX");
            playerBody.velocity = new Vector2(playerBody.velocity.x - .85f, playerBody.velocity.y - .85f);
        }
    }
}
