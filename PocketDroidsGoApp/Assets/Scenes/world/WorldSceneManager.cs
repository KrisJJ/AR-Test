using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : PocketDroidScenemanager
{
    public override void droidTapped(GameObject droid)
    {
        SceneManager.LoadScene(PocketDroidConstants.SCENE_CAPTURE,LoadSceneMode.Additive);
     
    }

    public override void PlayerTapped(GameObject player)
    {
  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
