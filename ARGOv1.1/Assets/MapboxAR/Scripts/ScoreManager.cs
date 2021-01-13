using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour

{
    public Text scoreText;
    public int score;
    private int finishScore;
    private List<string> finishList;
    private SpawnOnMap spawnOnMap;
    public GameObject ModalWindow;

    void Start()
    {
        score = 0;
        UpdateScore();
    }

 
    void UpdateScore() 
    {
        scoreText.text = "Счет: " + score;
        finishList = GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>()._locationStrings;
        if (finishList.Count == score)
        {
            ModalWindow.SetActive(true);
            //print(finishList.Count);
        }
        
       

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
}
