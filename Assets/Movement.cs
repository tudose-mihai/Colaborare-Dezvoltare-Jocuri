using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5f, jumpSpeed = 30f, radius = 3, jumpReach = 3;
    public Rigidbody2D rb2d;
    GameObject[] switch_magnets, toggle_magnets;
    public bool jumpAvailable;
    Vector3 circlePosition, xInput, yInput;
    LayerMask floorLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        switch_magnets = GameObject.FindGameObjectsWithTag("Switch Magnet");
        toggle_magnets = GameObject.FindGameObjectsWithTag("Toggle Magnet");
        floorLayer = LayerMask.GetMask("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        xInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        circlePosition = rb2d.transform.position - new Vector3(0, jumpReach, 0);
        
        print(jumpAvailable);
        if (Input.GetKeyDown(KeyCode.W) && jumpAvailable)
        {
            rb2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        foreach (GameObject magnet in toggle_magnets)
        {
            magnet.GetComponent<PointEffector2D>().forceMagnitude = 0;
            magnet.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetKey(KeyCode.F))
        {
            foreach (GameObject magnet in toggle_magnets)
            {
                magnet.GetComponent<PointEffector2D>().forceMagnitude = -100;
                magnet.GetComponent<SpriteRenderer>().color = Color.blue;

            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject magnet in switch_magnets)
            {
                magnet.GetComponent<PointEffector2D>().forceMagnitude *= -1;
                if (magnet.GetComponent<SpriteRenderer>().color == Color.green)
                    magnet.GetComponent<SpriteRenderer>().color = Color.red;
                else
                    magnet.GetComponent<SpriteRenderer>().color = Color.green;
            }

        }

    }

    void FixedUpdate()
    {
        rb2d.AddForce(xInput * Time.fixedDeltaTime * speed, ForceMode2D.Impulse);
        jumpAvailable = Physics2D.OverlapCircle(circlePosition, radius, floorLayer);
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

