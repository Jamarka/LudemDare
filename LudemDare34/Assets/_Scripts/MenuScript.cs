using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas buttons;
	
	private LevelManager levelManager;

	// Use this for initialization
	void Start () 
	{
		quitMenu = quitMenu.GetComponent<Canvas> ();
		buttons = buttons.GetComponent<Canvas> ();
		
		quitMenu.enabled = false;
	}
	
	public void QuitPress()
	{
		buttons.enabled = false;
		quitMenu.enabled = true;
	}
	
	public void NoPress()
	{
		buttons.enabled = true;
		quitMenu.enabled = false;
	}
	
}
