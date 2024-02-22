using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question : MonoBehaviour
{

    public TextMeshProUGUI coinsText;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnMouseDown()
    {
        if (gameManager != null)
        {

            gameManager.IncrementScore();
        }
    }
    void Update()
    {
        
    }
}
