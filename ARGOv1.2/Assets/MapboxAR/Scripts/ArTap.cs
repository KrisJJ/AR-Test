<<<<<<< HEAD
﻿using System.Collections;
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

        //UpdatePromptText();
        ARCamera.SetActive(false);
        
        MapboxCamera.SetActive(true);
        MapboxPromptPanel.SetActive(true);
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore();

        scoreText.text = "Ищи кристаллы!";
    }

}

=======
﻿using System.Collections;
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

        //UpdatePromptText();
        ARCamera.SetActive(false);
        
        MapboxCamera.SetActive(true);
        MapboxPromptPanel.SetActive(true);
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore();

        scoreText.text = "Ищи кристаллы!";
    }

}

>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
