using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour 
{
	[SerializeField] GameObject explosion; 
	[SerializeField] float levelDelay= 1f;

	void OnTriggerEnter(Collider other)
	{
		StartDeathSequence ();
	}
	void StartDeathSequence()
	{
		explosion.SetActive (true);
		SendMessage ("OnPlayerDeath");
		Invoke ("ReloadScene", levelDelay);
	}
	void ReloadScene()
	{
		SceneManager.LoadScene (1);
	}
}
