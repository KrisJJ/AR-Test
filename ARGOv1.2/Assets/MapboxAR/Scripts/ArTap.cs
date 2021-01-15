using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArTap : MonoBehaviour
{
    public GameObject ARCamera;
    public GameObject MapboxCamera;
    private void OnMouseDown()
    {
        ARCamera.SetActive(false);
        MapboxCamera.SetActive(true);
    }
}
