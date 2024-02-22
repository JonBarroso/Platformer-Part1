using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public LevelParser levelParser; 
    private void Update()
    {
        
    }

      private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
