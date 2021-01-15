using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject VuforiaCam;
    public GameObject MapBoxCam;

    public void Switchcam() {
        VuforiaCam.SetActive(true);
        MapBoxCam.SetActive(false);
    }

}
