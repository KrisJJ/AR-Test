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
        

    void Start()
    {
        _locationStrings = a_Dropdown.options.Select(x => x.text).ToList();

        _locations = new Vector2d[_locationStrings.Count];
        _spawnedObjects = new List<GameObject>();
        for (int i = 0; i < _locationStrings.Count; i++)
        {
            var locationString = _locationStrings[i];
            _locations[i] = Conversions.StringToLatLon(locationString);
            var instance = Instantiate(_markerPrefab);
            instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
            instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            _spawnedObjects.Add(instance);
        }
    }

    private void Update()
    {
        int count = _spawnedObjects.Count;
        for (int i = 0; i < count; i++)
        {
            var spawnedObject = _spawnedObjects[i];
            var location = _locations[i];
            if (spawnedObject != null)
            {
                spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
            }
        }
    }
}
