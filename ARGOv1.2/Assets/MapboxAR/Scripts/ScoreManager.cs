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
        finishList = GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>()._locationStrings;
        if (score == 0)
        {
            scoreText.text = "Ищите кристалы";
        }
        else {
            scoreText.text = "Кристалы: " + score + " / " + finishList.Count;
            if (finishList.Count == score)
            {
                ModalWindow.SetActive(true);
                //print(finishList.Count);
            }
        }

    }

    public void AddScore(int newScoreValue)
    {
        ModalWindow.SetActive(true);
        //score += newScoreValue;
        //UpdateScore();
    }
}
