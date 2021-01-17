using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamSwitch : MonoBehaviour
{
    public GameObject VuforiaCam;
    public GameObject MapBoxCam;
    public GameObject MapboxPromptPanel;
    public Text scoreText;

    public void Switchcam() {
        VuforiaCam.SetActive(true);
        
        MapBoxCam.SetActive(false);
        MapboxPromptPanel.SetActive(false);
        
        scoreText.text = "Ищи похожее изображение!";

    }

}
