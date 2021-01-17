using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UploadPrompts : MonoBehaviour
{
    public TMP_Text PromptTextObject;
    void Start()
    {
        PromptTextObject.text = GameObject.Find("PromptManager").GetComponent<PromptText>().promptsList[0];
        
    }
    private void Update()
    {
        int score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().score;
        PromptTextObject.text = GameObject.Find("PromptManager").GetComponent<PromptText>().promptsList[score];
    }

}
