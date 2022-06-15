using System.Collections.Generic;
using UnityEngine;
public class HighScores : MonoBehaviour
{
    public HighScoreDisplay[] highScoreDisplayArray;
    List<HighScoreEntry> scores = new List<HighScoreEntry>();
    
    void Start()
    {
        AddNewScore("John", 4500);
        AddNewScore("Max", 5520);
        AddNewScore("Dave", 380);
        AddNewScore("Steve", 6654);
        AddNewScore("Mike", 11021);
        AddNewScore("Teddy", 3252);
        UpdateDisplay();
        XMLManager.instance.SaveScores(scores);    
    }
    void UpdateDisplay()
    {
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => x.score.CompareTo(y.score));
        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(scores[i].name, scores[i].score);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }
    
    void AddNewScore(string entryName, int entryScore)
    {
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
    }
}