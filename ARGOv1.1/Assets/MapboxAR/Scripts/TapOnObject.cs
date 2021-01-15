using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TapOnObject : MonoBehaviour

{
    public int scoreValue;
    private ScoreManager scoreManager;

    private Vector2d currentLocation;

    public List<string> locationList;

    private SpawnOnMap spawnOnMap;

    public GameObject ModalWindow;

    private CamSwitch camSwitch;


    private void Start()
    {

        locationList = GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>()._locationStrings;

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
        
        currentLocation = GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>().currentLocation;
        

        if (currentLocation == Conversions.StringToLatLon(locationList[locationList.Count-1]))
        {
            //ModalWindow.SetActive(true);
           
            scoreManager.AddScore(scoreValue);
            print("приключения закончились");
            Destroy(gameObject);
        }
        else 
        {
            for (int i = 0; i < locationList.Count; i++)
            {
                if (Conversions.StringToLatLon(locationList[i]) == currentLocation) 
                {
                    //print("Текущий объект: " + currentLocation+ " "+ i);
                    GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>().UpdateLocation(Conversions.StringToLatLon(locationList[i+1]));
                    GameObject.Find("Obrabotchik").GetComponent<CamSwitch>().Switchcam();
                    //camSwitch.Switchcam();
                    break;
                }
            }
        }     

    }
}
