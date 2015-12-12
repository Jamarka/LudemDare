using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public bool isRunning = false;
	public bool canRun = true;
	public GameObject mouseLook;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {

		mouseLook = gameObject.transform.FindChild ("Main Camera").gameObject;
		Vector3 mousetemp = mouseLook.transform.rotation.eulerAngles;
		Vector3 temp = transform.rotation.eulerAngles;
		temp.y = mousetemp.y;
		transform.localRotation = Quaternion.Euler(temp);

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0 && canRun == true)
		{
			speed = 9;
			isRunning = true;
		}
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0 && canRun == true)
		{
			speed = 9;
			isRunning = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift) || canRun == false)
		{
			speed = 6;
			isRunning = false;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}