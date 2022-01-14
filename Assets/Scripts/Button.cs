using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void ButtonPress()
    {
        print("button quit");
        Application.Quit();
    }
}
