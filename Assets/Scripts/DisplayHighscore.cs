using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Text;
using System.IO;
using System.Globalization;
public class DisplayHighscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<float> scoreList = ReadScores();
        string highscores = "";

        for (int i = 0; i < Mathf.Min(5, scoreList.Count); i++)
        {
            
            string newLine = (i+1).ToString() + ": " + scoreList[i].ToString() + "\n";
            highscores += newLine;
        }
        GameObject[] messages;
        messages = GameObject.FindGameObjectsWithTag("End Text");
        messages[0].GetComponent<TMPro.TextMeshProUGUI>().text = highscores;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<float> ReadScores()
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
