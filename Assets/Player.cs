using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
	[SerializeField][Range(0,6000)] float speed=4f;
	[SerializeField]float xRange= 5f;
	[SerializeField] float yRange=2;
	[SerializeField] float positionPitchFactor  = -5f;
	[SerializeField] float positionYawFactor  = 5f;
	[SerializeField] float controlPitchFactor  = -20f;
	[SerializeField] float controlRollFactor  = -20;

	float yThrow;
	float yOffset;
	float xThrow ;


	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
		ProcessRotation();
	}
	void movement ()
	{
		YMovement ();
		XMovement ();

	}

	void XMovement ()
	{
		xThrow = CrossPlatformInputManager.GetAxis ("Horizontal");
		float xOffset = xThrow * speed * Time.deltaTime;
		// amount of movement per input
		float rawX = transform.localPosition.x + xOffset;
		//transformation by the movement offset
		float clampedX = Mathf.Clamp (rawX, -xRange, xRange);
		//restriction of the movement offset
		transform.localPosition = new Vector3 (clampedX, transform.localPosition.y, transform.localPosition.z);
		//new position with restricted offset
	}

	void YMovement()
	{
		 yThrow = CrossPlatformInputManager.GetAxis ("Vertical");
		 yOffset = yThrow * speed * Time.deltaTime;

		float rawY = transform.localPosition.y+yOffset;
		float clampY = Mathf.Clamp (rawY, -yRange, yRange);

		transform.localPosition= new Vector3 (transform.localPosition.x,clampY,transform.localPosition.z);
	}
	void ProcessRotation()
	{
		float pitch = transform.localPosition.y * positionPitchFactor + yThrow*controlPitchFactor;
		float yaw = transform.localPosition.x * positionYawFactor + xThrow * controlPitchFactor; 
		float roll = xThrow * controlRollFactor;
		transform.localRotation = Quaternion.Euler (pitch, yaw, roll);
	}
}
