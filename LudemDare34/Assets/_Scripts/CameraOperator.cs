using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraOperator : MonoBehaviour {

	public Texture2D selectionHighLight = null;
	public static Rect selsction = new Rect (0,0,0,0);
	private Vector3 startClick = -Vector3.one;

	private static Vector3 moveToDestination = Vector3.zero;
	private static List <string> passables = new List<string>(){ "Floor" };
	
	// Update is called once per frame
	void Update () 
	{
		CheckCamera ();
		CleanUp ();
	}

	private void CheckCamera()
	{
		if (Input.GetMouseButtonDown (0)) 
			startClick = Input.mousePosition;
		else if (Input.GetMouseButtonUp (0)) 
		{
			startClick = -Vector3.one;
		}

		if (Input.GetMouseButton(0))
			selsction = new Rect (startClick.x, InvertMouseY (startClick.y), Input.mousePosition.x - startClick.x, InvertMouseY (Input.mousePosition.y) - InvertMouseY (startClick.y));

			if (selsction.width < 0) 
			{
				selsction.x += selsction.width;
				selsction.width = -selsction.width;
			}
			if (selsction.height < 0) 
			{
				selsction.y += selsction.height;
				selsction.height = -selsction.height;
			}
	}

	private void OnGUI()
	{
		if (startClick != -Vector3.one)
		{
			GUI.color = new Color (1,1,1,0.5f);
			GUI.DrawTexture(selsction, selectionHighLight);
		}
	}

	public static float  InvertMouseY(float y)
	{
		return Screen.height - y;
	}

	private void CleanUp()
	{
		if (!Input.GetMouseButtonUp (1)) 
			moveToDestination = Vector3.zero;
	}

	public static Vector3 GetDestination()
	{
		if (moveToDestination == Vector3.zero)
		{
			RaycastHit hit;
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(r, out hit))
			{
				while (!passables.Contains(hit.transform.gameObject.name))
				{
					if (!Physics.Raycast(hit.point + r.direction *0.1f, r.direction, out hit))
						break;
				}
			}

			if (hit.transform != null)
				moveToDestination = hit.point;
		}
		return moveToDestination;
	}
}
