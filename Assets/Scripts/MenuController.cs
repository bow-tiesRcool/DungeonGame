using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject howToPlay;
	public GameObject options;
	public GameObject credits;

	public void OpenHowTo()
	{
		mainMenu.SetActive(false);
		howToPlay.SetActive(true);
	}

	public void OpenOptions()
	{
		mainMenu.SetActive(false);
		options.SetActive(true);
	}

	public void OpenCredits()
	{
		mainMenu.SetActive(false);
		credits.SetActive(true);
	}

	public void GoBack()
	{
		mainMenu.SetActive(true);
		howToPlay.SetActive(false);
		options.SetActive(false);
		credits.SetActive(false);
	}
}
