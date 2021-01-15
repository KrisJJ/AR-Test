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
    private Vector2d[] _locations;
    private List<GameObject> _spawnedObjects;
    public GameObject _markerPrefab;
    public AbstractMap _map;
    public List<string> _locationStrings;
    [SerializeField] private float _spawnScale;

    private GameObject spawnedObject;
    private Vector2d location;

    public Vector2d currentLocation;


    void Start()
    {
        _locationStrings = a_Dropdown.options.Select(x => x.text).ToList();

        currentLocation = Conversions.StringToLatLon(_locationStrings[0]);

        var instance = Instantiate(_markerPrefab);
        spawnedObject = instance;
        Transform();

    }

    private void Update()
    {
        if (spawnedObject != null)
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
    }
}
