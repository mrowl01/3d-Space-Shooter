using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBoss : MonoBehaviour
{


	public void Start ()
	{
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			Invoke ("LoadNextScene", 3.5f); 
		}
	}

	public void LoadNextScene()
	{
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentScene + 1);
	}
}
