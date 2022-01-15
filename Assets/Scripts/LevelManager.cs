using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string currentLevel, nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("level end collide");
        if (collision.gameObject.layer == 6)
        {
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);

        }
    }


    public void ButtonPress()
    {
        print("button level end");
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }

    public void ButtonPressHS()
    {
        print("button level end");
        SceneManager.LoadScene("Highscore", LoadSceneMode.Single);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject[] messages;

            messages = GameObject.FindGameObjectsWithTag("End Text");
            messages[0].GetComponent<TMPro.TextMeshProUGUI>().text = "Thanks for playing! \nScore: " + 4;

        }
    }
}
