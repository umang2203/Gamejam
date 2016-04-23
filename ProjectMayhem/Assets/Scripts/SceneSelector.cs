using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour 
{
	private GameObject currentPanel;
	private GameObject instructionsPanel;

	void Start()
	{
		currentPanel = GameObject.Find ("BG");
		instructionsPanel = GameObject.Find ("InstructionsPanel");
		instructionsPanel.SetActive (false);
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("Main");
	}

	public void InstructionsScreen()
	{
		currentPanel.SetActive (false);
		instructionsPanel.SetActive(true) ;
	}

	public void Back()
	{
		instructionsPanel.SetActive (false);
		currentPanel.SetActive (true);
	}

}
