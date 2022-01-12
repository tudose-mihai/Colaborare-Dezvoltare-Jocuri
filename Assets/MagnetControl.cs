using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetControl : MonoBehaviour
{
    GameObject[] switch_magnets, toggle_magnets;
    public int switchPolarity = -1, togglePolarity = -1, switchIntensity = 100, toggleIntensity = 100;
    // Start is called before the first frame update
    void Start()
    {
        switch_magnets = GameObject.FindGameObjectsWithTag("Switch Magnet");
        toggle_magnets = GameObject.FindGameObjectsWithTag("Toggle Magnet");
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject magnet in toggle_magnets)
        {
            magnet.GetComponent<PointEffector2D>().forceMagnitude = 0;
            magnet.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetKey(KeyCode.F))
        {
            foreach (GameObject magnet in toggle_magnets)
            {
                magnet.GetComponent<PointEffector2D>().forceMagnitude = toggleIntensity * togglePolarity;
                magnet.GetComponent<SpriteRenderer>().color = Color.blue;

            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject magnet in switch_magnets)
            {
                magnet.GetComponent<PointEffector2D>().forceMagnitude = switchIntensity * switchPolarity;
                switchPolarity *= -1;
                if (magnet.GetComponent<SpriteRenderer>().color == Color.green)
                    magnet.GetComponent<SpriteRenderer>().color = Color.red;
                else
                    magnet.GetComponent<SpriteRenderer>().color = Color.green;
            }

        }
    }
}
