using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SpawnOnMap : MonoBehaviour
{
    public Dropdown a_Dropdown;

    public GameObject _markerPrefab;
    public GameObject areaPrefab;
    public AbstractMap _map;
    public List<string> _locationStrings;
    [SerializeField] private float _spawnScale;

    private GameObject spawnedObject;
    private GameObject locationArea;
    public Vector2d currentLocation;


    void Start()
    {
        _locationStrings = a_Dropdown.options.Select(x => x.text).ToList();
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().UpdateScore();

        currentLocation = Conversions.StringToLatLon(_locationStrings[0]);

        var instance = Instantiate(_markerPrefab);
        spawnedObject = instance;
        instance = Instantiate(areaPrefab);
        locationArea = instance;
        Transform();

    }

    private void Update()
    {
        if (spawnedObject != null & locationArea != null)
        {
            Transform();
        }

    }
    public void UpdateLocation(Vector2d newLocation)
    {
        currentLocation = newLocation;
        Transform();
    }

    private void Transform()
    {
        spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
        spawnedObject.transform.localPosition = _map.GeoToWorldPosition(currentLocation, true);
        locationArea.transform.localScale = new Vector3(50,50,50);
        locationArea.transform.localPosition = _map.GeoToWorldPosition(currentLocation, true);
    }
}
