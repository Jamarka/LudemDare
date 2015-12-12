using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer musicPlayer = null;

	// Use this for initialization
	void Awake () {
		if (musicPlayer != null)
		{
			Destroy(gameObject);
			print ("Music Player is self destructing");
		}else
		{
			musicPlayer = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	
	}

}
