using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour {

	void Start () {
	}
	public void levelButtonPress()
	{
		SceneManager.LoadScene(2);
	}

	public void instructionButtonPress()
	{
		SceneManager.LoadScene(1);
	}

    public void retryButtonPress()
	{
		SceneManager.LoadScene(3);
	}

    public void level1ButtonPress()
	{
		SceneManager.LoadScene(3);
	}

    public void level2ButtonPress()
	{
		SceneManager.LoadScene(4);
	}

    public void level3ButtonPress()
	{
		SceneManager.LoadScene(5);
	}
}
