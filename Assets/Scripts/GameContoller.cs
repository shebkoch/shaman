using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameContoller : UnityEngine.MonoBehaviour
{
	public GameObject button;

	public static GameContoller instanse;

	private void Awake()
	{
		instanse = this;
	}

	public void Show()
	{
		button.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
}