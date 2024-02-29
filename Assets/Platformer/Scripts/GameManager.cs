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

    public TextMeshProUGUI MarioScoreText;
    public bool lost = false;

    private int coins = 0;
    private int score = 0;
    public void IncrementCoinsScore(int pointsToAdd)
    {
        coins++;
        CoinsText.text = "<sprite=0>x" + coins.ToString(); 
    }
        public void IncrementScore(int pointsToAdd)
    {
        score += pointsToAdd;
        MarioScoreText.text = "Score: " + score.ToString();
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float remainingTime = Mathf.Max(0, 100 - Time.realtimeSinceStartup); 
        int intTime = (int)remainingTime;
        string timeStr = $"Time \n {intTime}";
        timerText.text = timeStr;

        if (intTime <= 0 && !lost)
        {
            lost = true; 
            Debug.Log("You lose!");
        }
    }
}