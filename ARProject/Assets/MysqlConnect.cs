﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class MysqlConnect : MonoBehaviour
{
	public GameObject Registration;
	public Dropdown m_Dropdown;
	public GameObject Autorisation;
	public GameObject Profile;
	[SerializeField] private InputField userName;
	[SerializeField] private InputField userPass;
	[SerializeField] private InputField userEmail;
	[SerializeField] private Text NameUser;
	[SerializeField] private Text messageText;
	[SerializeField] private Text QuestL;
	[SerializeField] private Button register;
	[SerializeField] private Button login;
	[SerializeField] private string loginURL = "http://site.ru/login.php";
	[SerializeField] private string registerURL = "http://site.ru/register.php";
	[SerializeField] private string QuestsURL = "http://site.ru/quests.php";



	//void Drop() 
	//{
	//	var dropdown = transform.GetComponent<Dropdown>();

	//	dropdown.options.Clear();
	//}
	void Awake()
	{
		userPass.contentType = InputField.ContentType.Password;
		register.onClick.AddListener(() => { Register(); });
		login.onClick.AddListener(() => { Login(); });
		login.onClick.AddListener(() => { Quest(); });
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
		QuestL.text = text;
		Debug.Log(this + " --> " + text);
	}

	void Quest() {
		WWWForm form = new WWWForm();
		form.AddField("name", userName.text);
		WWW www = new WWW(QuestsURL, form);
		StartCoroutine(QuestFunc(www));
	}
	void Login()
	{
		if (!IsValid(userName.text, 3, 15, "Имя") || !IsValid(userPass.text, 6, 20, "Пароль")) return;

		WWWForm form = new WWWForm();
		form.AddField("name", userName.text);
		form.AddField("password", userPass.text);
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
		form.AddField("password", userPass.text);
		form.AddField("email", userEmail.text);
		WWW www = new WWW(registerURL, form);
		StartCoroutine(RegisterFunc(www));
	}

	IEnumerator QuestFunc(WWW www)
	{	
		yield return www;
		QuestList(www.text);
		m_Dropdown.options.Add(new Dropdown.OptionData(www.text));
	}
	IEnumerator LoginFunc(WWW www)
	{
		yield return www;

		if (www.error == null)
		{
			if (string.Compare(www.text, "Success!") == 0) // получаем в ответе слово-ключ из файла login.php
			{
				//Message("Успешный вход!  " + userName.text + " ");
				NameUs("Профиль " + userName.text + " ");
				m_Dropdown.options.Clear();
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
			Message("Пользователь успешно добавлен в базу.");
		}
		else
		{
			Message("Error: " + www.error);
		}
	}
}