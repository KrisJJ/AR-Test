using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArTap : MonoBehaviour
{
    public GameObject ARCamera;
    public GameObject MapboxCamera;
    public Text scoreText;
    public TMP_Text PromptTextObject;
    private void OnMouseDown()
    {

        //UpdatePromptText();
        ARCamera.SetActive(false);
        
        MapboxCamera.SetActive(true);

        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore();
    
        scoreText.text = "Ищи кристаллы!";
    }

}

