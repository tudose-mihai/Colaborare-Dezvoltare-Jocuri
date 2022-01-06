using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5f, maxSpeed = 30;
    public Rigidbody2D rb2d;
    public GameObject[] magnets;
    public bool attract = true;
    Vector3 xInput, yInput;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
        Debug.Log(magnets.Length);
    }

    // Update is called once per frame
    void Update()
    {
        xInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        yInput = new Vector3(0, Input.GetAxis("Vertical"), 0);
        if (Input.GetKeyDown("space")){
            //PointEffector2D magnetEffector = GameObject.Find("Magnet").GetComponent< PointEffector2D >();
            //PointEffector2D magnetEffector = magnets[0].GetComponent<PointEffector2D>();
            //magnetEffector.forceMagnitude *= -1;

            foreach (GameObject magnet in magnets)
            {
                magnet.GetComponent<PointEffector2D>().forceMagnitude *= -1;
                if (magnet.GetComponent<SpriteRenderer>().color == Color.green)
                    magnet.GetComponent<SpriteRenderer>().color = Color.red;
                else
                    magnet.GetComponent<SpriteRenderer>().color = Color.green;
            }

        }

    }
    // draw circle to indicate magnet radius
    // change magnets to circles ..
    // reduce speed
    // show intensity with a line
    void FixedUpdate()
    {
        rb2d.AddForce(xInput * Time.fixedDeltaTime * speed, ForceMode2D.Impulse);
        rb2d.AddForce(yInput * Time.fixedDeltaTime * speed, ForceMode2D.Impulse);
        rb2d.velocity = Vector3.ClampMagnitude(rb2d.velocity, maxSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("we collidin'");
    }
}

