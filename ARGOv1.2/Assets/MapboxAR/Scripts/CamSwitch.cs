using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamSwitch : MonoBehaviour
{
    public GameObject VuforiaCam;
    public GameObject MapBoxCam;
    public Text scoreText;

    public void Switchcam() {
        VuforiaCam.SetActive(true);
        
        MapBoxCam.SetActive(false);
        
        scoreText.text = "Ищи похожее изображение!";

    }

}
