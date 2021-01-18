using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StartQuest : MonoBehaviour
{
    public Dropdown a_Dropdown; 
    public Dropdown b_Dropdown;
    public Dropdown c_Dropdown;
    public Button StartButton;
    public List<string> questTypes;
    public List<string> locationStrings;
    public List<string> prompts;



    private void Awake()
    {
        StartButton.onClick.AddListener(() => { OnMouseDown(); });
    }
    private void OnMouseDown()
    {


        questTypes = a_Dropdown.options.Select(x => x.text).ToList();
        GameObject.Find("QuestTypeManager").GetComponent<OpenTypeQuest>().questTypes = questTypes;

        locationStrings = b_Dropdown.options.Select(x => x.text).ToList();
        GameObject.Find("QuestTypeManager").GetComponent<OpenTypeQuest>().locationStrings = locationStrings;

        prompts = c_Dropdown.options.Select(x => x.text).ToList();
        GameObject.Find("QuestTypeManager").GetComponent<OpenTypeQuest>().prompts = prompts;

        GameObject.Find("QuestTypeManager").GetComponent<OpenTypeQuest>().OnMouseDown();
    }


}
