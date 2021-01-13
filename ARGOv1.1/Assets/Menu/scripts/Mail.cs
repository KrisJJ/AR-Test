using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Mail : MonoBehaviour
{

    [SerializeField] private InputField userName;
    [SerializeField] public Text Email;
    [SerializeField] private Button start;
    [SerializeField] private string EmailURL = "http://localhost/email.php";

    void Awake()
    {
        start.onClick.AddListener(() => { EmailFind(); });
    }
    void EmailFind()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", userName.text);
        WWW www = new WWW(EmailURL, form);
        StartCoroutine(Emailtext(www));
    }

    void Emailtextt(string text)
    {
        Email.text = text;
        Debug.Log(this + " --> " + text);
    }
    IEnumerator Emailtext(WWW www)
    {
        yield return www;
        Emailtextt(www.text);
    }




}

