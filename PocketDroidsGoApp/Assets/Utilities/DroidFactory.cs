
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Assert = UnityEngine.Assertions.Assert;

public class DroidFactory : Singleton<DroidFactory>
{

    [SerializeField] private Droid[] availableDroids;
    [SerializeField] private Player player;
    [SerializeField] private float waitTime = 180.0f;
    [SerializeField] private int startingDroids = 5;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    private List<Droid> liveDroids = new List<Droid>();
    private Droid selectedDroid;

    private void Awake() 
    {
        Assert.IsNotNull(availableDroids);
        Assert.IsNotNull(player);
    }

    void Start()
    {
        for (int i = 0; i < startingDroids; i++) 
        {
            InstaniateDroid();
        }
        StartCoroutine(GenerateDroids());
    }

    public void DroidWasSelected(Droid droid) {
        selectedDroid = droid;
    }

    private IEnumerator GenerateDroids() 
    {
        while (true) 
        {
            InstaniateDroid();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void InstaniateDroid() 
    {
        int index = Random.Range(0, availableDroids.Length);
        float x = player.transform.position.x + GenerateRange();
        float y = player.transform.position.y + GenerateRange();
        float z = player.transform.position.z + GenerateRange();

        liveDroids.Add(Instantiate(availableDroids[index], new Vector3(x, y, z), Quaternion.identity));


    }

    private float GenerateRange() 
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;

        return randomNum * (isPositive ? 1 : -1);
    }

  
}
