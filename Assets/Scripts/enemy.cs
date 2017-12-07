using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider))]
public class enemy : MonoBehaviour 
{
	[SerializeField] GameObject explosion;
	[SerializeField] int scorePerHit =12;
	ScoreBoard scoreBoard;
	[SerializeField] int hits= 5;

	void Start()
	{
		scoreBoard = GameObject.FindObjectOfType<ScoreBoard> ();

		if ( gameObject.GetComponent<BoxCollider> () == null) {

			gameObject.AddComponent<BoxCollider> ();
		}
		gameObject.GetComponent<BoxCollider> ().isTrigger = false;
	}

	void OnParticleCollision(GameObject other)
	{
		scoreBoard.ScoreHit (scorePerHit);
		hits--;
		if (hits <= 0) 
		{
			EnemyDeath ();
		}

	}
	void EnemyDeath()
	{
		GameObject fx = Instantiate (explosion, transform.position, Quaternion.identity);
		fx.transform.parent = GameObject.Find ("DestoryChild").transform ;
		Destroy (gameObject);
	}
}
