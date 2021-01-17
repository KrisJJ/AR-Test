using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour

{
    public int score;

    private List<string> finishList;

    public GameObject ModalWindow;

    public GameObject MapboxPromptPanel;

    void Start()
    {
        score = 0;
    }

 
    public void UpdateScore() 
    {
        finishList = GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>()._locationStrings;
    }

    public void AddScore()
    {        
        score += 1;
        print(score);
        

<<<<<<< HEAD
        if (score == finishList.Count)
        {
            ModalWindow.SetActive(true);
            MapboxPromptPanel.SetActive(false);


=======
        if (score == finishList.Count)
        {
            ModalWindow.SetActive(true);
            MapboxPromptPanel.SetActive(false);


>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
        }
       
        
    }
}
