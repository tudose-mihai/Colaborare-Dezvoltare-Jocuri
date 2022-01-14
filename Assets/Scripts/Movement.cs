using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5f, jumpSpeed = 30f;
    float radius = 0.2f, jumpReach = 0.1f;
    public int maxSpeed = 5;
    Rigidbody2D rb2d;
    AudioSource audio;
    bool jumpAvailable;
    Vector3 circlePosition, xInput, yInput, startPosition;
    LayerMask floorLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPosition = rb2d.transform.position;
        floorLayer = LayerMask.GetMask("Floor");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        circlePosition = rb2d.transform.position - new Vector3(0, jumpReach, 0);
        
        if (Input.GetKeyDown(KeyCode.W) && jumpAvailable)
        {
            rb2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb2d.transform.position = startPosition;
            rb2d.velocity = Vector3.zero;
        }

    }

    void FixedUpdate()
    {
        rb2d.AddForce(xInput * Time.fixedDeltaTime * speed, ForceMode2D.Impulse);
        jumpAvailable = Physics2D.OverlapCircle(circlePosition, radius, floorLayer);
        
        if(rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;

        }
        print(rb2d.velocity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("we trigger collidin'");
    }
    void OnCollisionStay2D(Collision2D collisionObject)
    {
        if (collisionObject.gameObject.layer == floorLayer)
        {
            //jumpAvailable = true;
        }
    }

    void OnDrawGizmos()
    {
        //Color of gizmos is blue.
        Gizmos.color = Color.blue;
        //Gizmos is to draw a wire sphere using the grounder.transform's position, and the radius value.
        Gizmos.DrawWireSphere(circlePosition, radius);
    }

}

