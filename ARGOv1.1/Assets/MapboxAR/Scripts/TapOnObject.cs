using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TapOnObject : MonoBehaviour

{
    [SerializeField] private AudioClip TapSound;
    private AudioSource audio;
    public int scoreValue;
    private ScoreManager scoreManager;

    private void Start()
    {
      
        audio = GetComponent<AudioSource>();

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
        
        audio.PlayOneShot(TapSound);
        //не успевает проиграть звук

        scoreManager.AddScore(scoreValue);

        Destroy(gameObject);
    }
}
