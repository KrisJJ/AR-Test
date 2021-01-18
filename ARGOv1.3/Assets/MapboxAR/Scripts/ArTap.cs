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
    public GameObject MapboxPromptPanel;
    private void OnMouseDown()
    {
        GameObject.Find("QuestTypeManager").GetComponent<OpenTypeQuest>().OpenNewQuest();
        //GameObject.Find("QuestTypeManager").GetComponent<OpenTypeQuest>().ChangePos();
        /*
        //UpdatePromptText();
        ARCamera.SetActive(false);
        
        MapboxCamera.SetActive(true);
        MapboxPromptPanel.SetActive(true);
        */
        //GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore();

        scoreText.text = "Ищи кристаллы!";
    }

}

