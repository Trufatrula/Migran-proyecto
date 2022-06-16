using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;
    public void DisplayHighScore(string name, int score)
    {
        nameText.text = name;
        float minutes = Mathf.FloorToInt(score / 60); 
        float seconds = Mathf.FloorToInt(score % 60);
        scoreText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void HideEntryDisplay()
    {
        nameText.text = "";
        scoreText.text = "";
    }
}