using UnityEngine;
using System.Collections;

public class UnitsControls : MonoBehaviour {

	public bool selected = false;
	public Renderer unitrenderer;

	private Vector3 moveToDest = Vector3.zero;
	public float floorOffSet = 1;
	public float speed = 5;
	public float stopDistanceOffset = 0.5f;
	public MeshRenderer highLightMesh;
	private bool selectedByClick = false;

	// Update is called once per frame


	void Update () 
	{
		if (unitrenderer.isVisible && Input.GetMouseButton(0))
		{
			if (!selectedByClick)
			{
				Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
				camPos.y = CameraOperator.InvertMouseY(camPos.y);
				selected = CameraOperator.selsction.Contains(camPos);
			}

			if (selected)
			{
				highLightMesh.enabled = true;
			}else
			{
				highLightMesh.enabled = false;
			}
		}

		if (selected && Input.GetMouseButtonUp(1))
		{
			Vector3 destination = CameraOperator.GetDestination();
			if (destination != Vector3.zero)
			{
				moveToDest = destination;
				moveToDest.y += floorOffSet;
			}
		}
		UpdateMove();
	}

	private void UpdateMove()
	{
		if (moveToDest != Vector3.zero && transform.position != moveToDest) 
		{
			Vector3 direction = (moveToDest - transform.position).normalized;
			direction.y = 0;
			transform.GetComponent<Rigidbody>().velocity = direction * speed;

			if (Vector3.Distance (transform.position, moveToDest) < stopDistanceOffset)
				moveToDest = Vector3.zero;
		} 
		else
			transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	private void OnMouseDown()
	{
		selectedByClick = true;
		selected = true;
	}

	private void OnMouseUp()
	{
		if (selectedByClick)
			selected = true;

		selectedByClick = false;
	}
}
