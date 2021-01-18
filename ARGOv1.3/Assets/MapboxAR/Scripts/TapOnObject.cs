using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TapOnObject : MonoBehaviour

{
    private Vector2d currentLocation;

    public List<string> locationList;

    public GameObject ModalWindow;   

    private void Start()
    {
        locationList = GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>()._locationStrings;
    }
    private void OnMouseDown()
    {
        currentLocation = GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>().currentLocation;

        if (currentLocation == Conversions.StringToLatLon(locationList[locationList.Count-1]))
        {
            Destroy(gameObject);
        }
        else 
        {
            for (int i = 0; i < locationList.Count; i++)
            {
                if (Conversions.StringToLatLon(locationList[i]) == currentLocation) 
                {
                    GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>().UpdateLocation(Conversions.StringToLatLon(locationList[i+1]));
                    break;
                }
            }
        }
        GameObject.Find("Obrabotchik").GetComponent<CamSwitch>().Switchcam();
        GameObject.Find("OpenPromptButton").SetActive(false);

    }
}
