using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System.Linq;

public class MysqlConnect : MonoBehaviour
{
	public GameObject Registration;
	public Dropdown m_Dropdown;
	public GameObject Autorisation;
	public GameObject Profile;
    [SerializeField] public Text Email;
    [SerializeField] private InputField userName;
	[SerializeField] private InputField userPass;
	[SerializeField] private InputField userEmail;
	[SerializeField] private Text NameUser;
	[SerializeField] private Text messageText;
	[SerializeField] private Button register;
	[SerializeField] private Button login;
    [SerializeField] private string EmailURL = "http://localhost/email.php";
    [SerializeField] private string loginURL = "http://localhost/login.php";
	[SerializeField] private string registerURL = "http://localhost/register.php";
	[SerializeField] private string QuestsURL = "http://localhost/quests.php";


	void Awake()
	{
		userPass.contentType = InputField.ContentType.Password;
		register.onClick.AddListener(() => { Register(); });
		login.onClick.AddListener(() => { Login(); });
		login.onClick.AddListener(() => { Quest(); });
        login.onClick.AddListener(() => { EmailFind(); });
    }

	bool IsValidEmail(string email) // валидация email
	{
		return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
	}

	bool IsValid(string value, int min, int max, string field) // валидация имени и пароля
	{
		if (value.Length < min)
		{
			Message("В поле [ " + field + " ] недостаточно символов, нужно минимум [ " + min + " ]");
			return false;
		}
		else if (value.Length > max)
		{
			Message("В поле [ " + field + " ] допустимый максимум символов, не более [ " + max + " ]");
			return false;
		}
		else if (Regex.IsMatch(value, @"[^\w\.@-]"))
		{
			Message("В поле [ " + field + " ] содержаться недопустимые символы.");
			return false;
		}

		return true;
	}

    void Emailtextt(string text)
    {
        Email.text = text;
        Debug.Log(this + " --> " + text);
    }
    void Message(string text)
	{
		messageText.text = text;
		Debug.Log(this + " --> " + text);
	}

	void NameUs(string text)
	{
		NameUser.text = text;
		Debug.Log(this + " --> " + text);
	}
	void QuestList(string text)
	{
	}
        void EmailFind()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", userName.text);
        WWW www = new WWW(EmailURL, form);
        StartCoroutine(Emailtext(www));
    }

	void Quest() {
		WWWForm form = new WWWForm();
		form.AddField("creator", userName.text);
		WWW www = new WWW(QuestsURL, form);
		StartCoroutine(QuestFunc(www));
	}
	void Login()
	{
		if (!IsValid(userName.text, 3, 15, "Имя") || !IsValid(userPass.text, 6, 20, "Пароль")) return;

		WWWForm form = new WWWForm();
		form.AddField("name", userName.text);
		form.AddField("pass", userPass.text);
		WWW www = new WWW(loginURL, form);
		StartCoroutine(LoginFunc(www));
	}

	void Register()
	{
		if (!IsValidEmail(userEmail.text))
		{
			Message("Email адрес указан не верно!");
			return;
		}

		if (!IsValid(userName.text, 3, 15, "Имя") || !IsValid(userPass.text, 6, 20, "Пароль")) return;

		WWWForm form = new WWWForm();
		form.AddField("name", userName.text);
		form.AddField("pass", userPass.text);
		form.AddField("email", userEmail.text);
		WWW www = new WWW(registerURL, form);
		StartCoroutine(RegisterFunc(www));
	}

	IEnumerator QuestFunc(WWW www)
	{
		yield return www;
		QuestList(www.text);
		string otvet = www.text;
		string[] questt = otvet.Split (new string[] { "|NEXT|" }, System.StringSplitOptions.None);
		var list = questt.ToList();
        m_Dropdown.options.Clear();
        m_Dropdown.AddOptions(list);
	}

    IEnumerator Emailtext(WWW www)
    {
        yield return www;
        Emailtextt(www.text);
    }

    IEnumerator LoginFunc(WWW www)
	{
		yield return www;

		if (www.error == null)
		{
			if (string.Compare(www.text, "Success!") == 0) // получаем в ответе слово-ключ из файла login.php
			{
				//Message("Успешный вход!  " + userName.text + " ");
				NameUs(userName.text);
				Autorisation.SetActive (false);
				Registration.SetActive (false);
				Profile.SetActive (true);

			}
			else
			{
				Message(www.text);
			}
		}
		else
		{
			Message("Error: " + www.error);
		}
	}

	IEnumerator RegisterFunc(WWW www)
	{
		yield return www;

		if (www.error == null)
		{
			Message("Вы успешно зарегистрировались!.");
		}
		else
		{
			Message("Error: " + www.error);
		}
	}
}