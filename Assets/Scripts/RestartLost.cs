using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLost : MonoBehaviour 
{
	// How to create and use a Button with an onClick event listener:
	// 1st) In order to use a UI button, you need to add the UnityEngine UI library by adding it at the top of the script (see above)
	// 2nd) This script needs to be added on a GameObject (review the GameObject "Player"). 
	// 3rd) A UI button needs to be added in the scenes "Hierarchy".
	// 4th) The created UI button needs to be dropped into the public field on the GameObject the script is attached to, e.g. "Player".
	// 5th) On the UI button, at the OnClick window, add a new item to the list with "+";
	//      then select the GameObject, the script is attached to; select this scripts name and method, e.g. "Restart.RestartScene()"!
	
	// public field to link the UI button
	public Button restartButtonLost;
	public Button restartButtonWon;
	
	void Start()
	{
		// creates a listener for the method
		restartButtonLost.onClick.AddListener(RestartScene);
		restartButtonWon.onClick.AddListener(RestartScene);
	}

	// restarts the currently active scene
	public void RestartScene()
	{
		Debug.Log("Game Restarted!");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}