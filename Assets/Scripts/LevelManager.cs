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
            SceneManager.UnloadSceneAsync(currentLevel);

        }
    }

    public void ButtonPress()
    {
        print("button level end");
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }
}
