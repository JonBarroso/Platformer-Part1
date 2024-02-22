using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    public TextMeshProUGUI CoinsText;

    private int score = 0;

    // Method to increment the score
    public void IncrementScore()
    {
        score++;
        CoinsText.text = "<sprite=0>x" + score.ToString(); // Update the coin text UI with the new score
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        int intTime = 400 - (int)(Time.realtimeSinceStartup * 2.5);
        string timeStr = $"Time \n {intTime}";
        timerText.text = timeStr;
    }
}