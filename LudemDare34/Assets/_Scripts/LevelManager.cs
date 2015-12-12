using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private int lastLevel;

	public void LoadLevel (string name) 
	{	
		PlayerPrefs.SetInt("Last_Level", Application.loadedLevel);
		lastLevel = Application.loadedLevel;	
		Application.LoadLevel (name);
	}
	
	public void Retry()
	{
		Application.LoadLevel (lastLevel);
	}
	
	// When back button is clicked retrieves the name of the previous level from 
	// the last Level varible.
	public void Back()
	{
		Application.LoadLevel (PlayerPrefs.GetInt ("Last_Level"));
	}
		
	public void Quit ()
	{
		print ("Quitting Game");
		Application.Quit ();
	}

}
