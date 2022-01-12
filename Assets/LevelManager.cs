using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("level end collide");
        if (collision.gameObject.layer == 6)
        {
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
            SceneManager.UnloadSceneAsync("SampleScene");

        }
    }
}
