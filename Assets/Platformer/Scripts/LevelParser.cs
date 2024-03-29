using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject spikePrefab;
    public GameObject goalPrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }
        int row = 0;

        // Go through the rows from bottom to top
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (int col = 0; col < letters.Length; col++)
            {
                var letter = letters[col];
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                if (letter == 'x')
                {
                    Vector3 newPos = new Vector3(col, row, 0f);
                    GameObject newObj = Instantiate(rockPrefab, newPos, Quaternion.identity, environmentRoot);
                    //Transform newTransform = newObj.transform;
                    //newTransform.position = newPos;
                }
                if (letter == 'b')
                {
                    Vector3 newPos = new Vector3(col, row, 0f);
                    GameObject newObj = Instantiate(brickPrefab, newPos, Quaternion.identity, environmentRoot);
                    //Transform newTransform = newObj.transform;
                    //newTransform.position = newPos;
                    if(newObj != null)
                    {
                        AddClickHandler(newObj);
                    }
                    
                }
                if (letter == 's')
                {
                    Vector3 newPos = new Vector3(col, row, 0f);
                    GameObject newObj = Instantiate(stonePrefab, newPos, Quaternion.identity, environmentRoot);
                    //Transform newTransform = newObj.transform;
                    //newTransform.position = newPos;
                }
                if (letter == '?')
                {
                    Vector3 newPos = new Vector3(col, row, 0f);
                    GameObject newObj = Instantiate(questionBoxPrefab, newPos, Quaternion.identity, environmentRoot);
                    //Transform newTransform = newObj.transform;
                    //newTransform.position = newPos;
                    if(newObj != null)
                    {
                        AddClickHandler(newObj);
                    }
                }
                if (letter == 'e')
                {
                    Vector3 newPos = new Vector3(col, row, 0f);
                    GameObject newObj = Instantiate(spikePrefab, newPos, Quaternion.identity, environmentRoot);
                    //Transform newTransform = newObj.transform;
                    //newTransform.position = newPos;
                }
                if (letter == 'g')
                {
                    Vector3 newPos = new Vector3(col, row, 0f);
                    GameObject newObj = Instantiate(goalPrefab, newPos, Quaternion.identity, environmentRoot);
                    //Transform newTransform = newObj.transform;
                    //newTransform.position = newPos;
                }
            }
                row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
    private void AddClickHandler(GameObject obj)
    {
        var clickable = obj.AddComponent<Brick>();
        clickable.levelParser = this;
    }

}
