using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class TypeProc : MonoBehaviour
{
    public Dropdown m_Dropdown;
    public Dropdown a_Dropdown;
    public List<string> list;

    [SerializeField] private Button start;
    [SerializeField] private Button check;
    [SerializeField] private string QuestsURL = "http://localhost/type.php";

    void Awake()
    {
        start.onClick.AddListener(() => { Coordin(); });
        check.onClick.AddListener(() => { Coordin1(); });
    }
    void Coordin()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", m_Dropdown.options[m_Dropdown.value].text); //тут я должен получить название квеста
        WWW www = new WWW(QuestsURL, form);
        StartCoroutine(QuestFunc(www));
    }
    void Coordin1()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", m_Dropdown.options[m_Dropdown.value].text); //тут я должен получить название квеста
        WWW www = new WWW(QuestsURL, form);
        StartCoroutine(QuestFunc1(www));
    }

    void CoorList(string text)
    {

    }
    IEnumerator QuestFunc(WWW www)
    {
        yield return www;
        CoorList(www.text);
        string otvet = www.text;
        string[] MyList = otvet.Split(new string[] { "|NEXT|" }, System.StringSplitOptions.None);
        list = MyList.ToList();
        a_Dropdown.options.Clear();
        a_Dropdown.AddOptions(list);
    }

    IEnumerator QuestFunc1(WWW www)
    {
        yield return www;
        CoorList(www.text);
        string otvet = www.text;
        string[] MyList = otvet.Split(new string[] { "|NEXT|" }, System.StringSplitOptions.None);
        list = MyList.ToList();
        a_Dropdown.options.Clear();
        a_Dropdown.AddOptions(list);
    }



}
