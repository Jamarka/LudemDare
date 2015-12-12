using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public int speed = 5;
	private Quaternion angle;
	private float myYAngle;
	// Use this for initialization
	void Start () {
		myYAngle = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
	

		if (Input.GetKey(KeyCode.D))
		{
			transform.position =  new Vector3(transform.position.x + speed * Time.deltaTime,transform.position.y,transform.position.z);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position =  new Vector3(transform.position.x - speed * Time.deltaTime,transform.position.y,transform.position.z);
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.position =  new Vector3(transform.position.x,transform.position.y,transform.position.z  + speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position =  new Vector3(transform.position.x,transform.position.y,transform.position.z  - speed * Time.deltaTime);
		}

		//Extra if have time

		//pans the camera

//		angle = Quaternion.Euler(40,myYAngle, 0);
//		Debug.Log (angle);
//		transform.rotation = angle;
//
//		Debug.Log (angle);
//
//		if (Input.GetKeyDown(KeyCode.E))
//		{
//			myYAngle = myYAngle - 45;
//		}
//		if (Input.GetKeyDown(KeyCode.Q))
//		{
//			myYAngle = myYAngle + 45;
//		}

	}
}
