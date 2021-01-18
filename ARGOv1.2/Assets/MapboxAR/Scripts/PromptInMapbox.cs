<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptInMapbox : MonoBehaviour
{
    public Text text;
    private List<string> list;
    void Start()
    {
        
    }


    void Update()
    {
        int score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().score;

        if (GameObject.Find("PromptManager").GetComponent<PromptText>().promptsList.Count != 0) 
        {
            text.text = GameObject.Find("PromptManager").GetComponent<PromptText>().promptsList[score];
        }
        
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptInMapbox : MonoBehaviour
{
    public Text text;
    private List<string> list;
    void Start()
    {
        
    }


    void Update()
    {
        int score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().score;

        if (GameObject.Find("PromptManager").GetComponent<PromptText>().promptsList.Count != 0) 
        {
            text.text = GameObject.Find("PromptManager").GetComponent<PromptText>().promptsList[score];
        }
        
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
