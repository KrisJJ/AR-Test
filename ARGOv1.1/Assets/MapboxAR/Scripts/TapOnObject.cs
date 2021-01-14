using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TapOnObject : MonoBehaviour

{
    public int scoreValue;
    private ScoreManager scoreManager;

    private void Start()
    {
      
        GameObject ScoreManagerObject = GameObject.FindWithTag("ScoreManager");

       

        if (ScoreManagerObject != null)
        {
            scoreManager = ScoreManagerObject.GetComponent<ScoreManager>();
            
        }
        if (ScoreManagerObject == null)
        {
            print("скрипт ScoreManager не найден");
        }
    }
    private void OnMouseDown()
    {
        
        scoreManager.AddScore(scoreValue);

        Destroy(gameObject);
    }
}
