using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenTypeQuest : MonoBehaviour
{

    public int current;
    public List<string> questTypes;
    public List<string> locationStrings;
    public List<string> prompts;
    public GameObject VuforiaCam;
    public List<string> list;
    public int pos;

    public GameObject debugPath;
    public GameObject EndPanel;
    public GameObject ARRoot;
    public GameObject ARPlayer;
    public GameObject ArAlignedMap;
    public GameObject MapCamera;
    public GameObject CameraSelection;
    public GameObject ToggleConsoleButton;
    public GameObject LocationProvider;
    public GameObject Text;
    public GameObject PromptPanel;
    public Text promptText;
    public TMP_Text PromptTextObject;
    public Button StartButton;



    public Dropdown a_Dropdown;

    private void Start()
    {
        current = 0;
        pos = -1;
    }
    public void OnMouseDown()
    {
        OpenNewQuest();
    }

    public void OpenNewQuest() 
    {
        ChangePos();

        print("1111111111");
        print(questTypes[0]);
        print(questTypes[1]);
        print(questTypes[2]);

        if (current > questTypes.Count-1)
        {

            EndPanel.SetActive(true);

        }
        else 
        { 
            if (questTypes[current] == "1")
            {
                OpenCloseMapbox(true);
                VuforiaCam.SetActive(false);

                for (int i = 0; i < locationStrings.Count(); i++)
                {
                    if (locationStrings[i] != "null")
                    {
                        GameObject.Find("ArAlignedMap").GetComponent<SpawnOnMap>().Start1(locationStrings[i]);
                        locationStrings[i] = "null";
                        //pos = i;

                        break;
                   
                    }
                }
            
           
                //promptText.text = "1222121212212121212";




            }
            if (questTypes[current] == "2")
            {
                VuforiaCam.SetActive(true);
            
                PromptTextObject.text = prompts[pos+1];
                OpenCloseMapbox(false);
            
            }

        
            

            
        }
        current++;
        promptText.text = prompts[pos];

    }

    public void OpenCloseMapbox(bool n) 
    {
        MapCamera.SetActive(n);
        debugPath.SetActive(n);
        ARRoot.SetActive(n);
        ARPlayer.SetActive(n);
        ArAlignedMap.SetActive(n);
        
        CameraSelection.SetActive(n);
        ToggleConsoleButton.SetActive(n);
        LocationProvider.SetActive(n);
        Text.SetActive(n);
        

    }


    public void ChangePos() 
    {
        pos++;
        print("ПОДСКАЗКА "+pos);
    }
}

