using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
using System.Globalization;

public class Timer : MonoBehaviour
{
    float startTime;
    GameObject[] objs, messages;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        

    }

    void OnEnable()
    {
        objs = GameObject.FindGameObjectsWithTag("Timer");
        startTime = Time.time;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        //print(Time.time - startTime);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "The End")
        {
            float finalTime = (Time.time - startTime);

            messages = GameObject.FindGameObjectsWithTag("End Text");
            if(messages.Length > 0)
            {
                messages[0].GetComponent<TMPro.TextMeshProUGUI>().text = "Thanks for playing! \nScore: " + finalTime;
            }

            //print("Final time: " + finalTime);
            WriteScore(finalTime);


            List<float> scoreList = ReadScores();

            Destroy(objs[0]);
        }
        //Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
    }

    public static void WriteScore(float finalTime)
    {
        string path = Application.persistentDataPath + "/highscore.txt";
        
        string newLine = finalTime.ToString() + "\n";
        File.AppendAllText(path, newLine, Encoding.UTF8);

        List<float> scoreList = new List<float>();
        string[] readText = File.ReadAllLines(path, Encoding.UTF8);
        foreach (string s in readText)
        {
            float value = float.Parse(s);
            scoreList.Add(value);
        }
        scoreList.Sort();
        /*foreach (float value in scoreList)
        {
            print(value);
        }*/
    }
    List<float>  ReadScores()
    {
        List<float> scoreList = new List<float>();
        string path = Application.persistentDataPath + "/highscore.txt";
        string[] readText = File.ReadAllLines(path, Encoding.UTF8);
        foreach (string s in readText)
        {
            float value = float.Parse(s);
            scoreList.Add(value);
        }
        foreach (float value in scoreList)
        {
            print(value);
        }
        return scoreList;
    }
}
