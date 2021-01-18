<<<<<<< HEAD
﻿using System.Collections;
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
        
        scoreText.text = " ";

    }

}
=======
<<<<<<< HEAD
﻿using System.Collections;
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
=======
﻿using System.Collections;
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
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
>>>>>>> master
