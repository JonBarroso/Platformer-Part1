using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public LevelParser levelParser; 
    public LevelParser2 levelParser2; 
    private GameManager gameManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 Colide = collision.contacts[0].point;
            Vector3 brickHit = transform.position;
            if (Colide.y < brickHit.y)
            {
                Destroy(gameObject);

                if (gameManager != null)
                {
                  gameManager.IncrementScore(100);
                }
            }
        }
    }
      private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
