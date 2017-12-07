using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider))]
public class enemy : MonoBehaviour 
{
	[SerializeField] GameObject explosion;
	void Start()
	{

		if ( gameObject.GetComponent<BoxCollider> () == null) {

			gameObject.AddComponent<BoxCollider> ();
		}
		gameObject.GetComponent<BoxCollider> ().isTrigger = false;
	}

	void OnParticleCollision(GameObject other)
	{
		GameObject fx = Instantiate (explosion, transform.position, Quaternion.identity);
		fx.transform.parent = GameObject.Find ("DestoryChild").transform ;
		Destroy (gameObject);
	}
}
