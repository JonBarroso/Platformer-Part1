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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 Colide2 = collision.contacts[0].point;
            Vector3 questionHit = transform.position;
            if (Colide2.y < questionHit.y)
            {
                gameManager.IncrementCoinsScore(100);
            }
        }
    }
    private void OnMouseDown()
    {
        if (gameManager != null)
        {

            gameManager.IncrementCoinsScore(100);
        }
    }
    void Update()
    {
        
    }
}
