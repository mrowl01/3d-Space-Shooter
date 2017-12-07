using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour 
{
	int score = 0;
	Text text;

	void Start()
	{
		text = GetComponent<Text> ();
		text.text = score.ToString ();
	}
	public void ScoreHit(int scoreIncrease)
	{
		score = score + scoreIncrease;
		text.text = score.ToString ();
	}
}
