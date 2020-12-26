using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Droid : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.01f;
    [SerializeField] private float catchRate = 0.01f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defense = 0;
    [SerializeField] private int hp = 0;
    [SerializeField] private AudioClip crySound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(crySound);
    }

    private void Start() {
        DontDestroyOnLoad(this);
    }

    public float SpawnRate {
        get { return spawnRate; }   
    }
    public float CatchRate {
        get { return catchRate; }
    }
    public int Attack {
        get { return attack; }
    }
    public int Defence {
        get { return defense; }
    }
    public int Hp {
        get { return hp; }
    }

    private void OnMouseDown() {
        PocketDroidScenemanager[] managers = FindObjectsOfType<PocketDroidScenemanager>();
        audioSource.PlayOneShot(crySound);
        foreach (PocketDroidScenemanager pocketDroidScenemanager in managers) { 
            if (pocketDroidScenemanager.gameObject.activeSelf)
            {
                pocketDroidScenemanager.droidTapped(this.gameObject);
            }
        }

    }

}
