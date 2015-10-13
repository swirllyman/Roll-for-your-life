using UnityEngine;
using System.Collections;

public class SoundLooper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleSound()
	{
		GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;
	}
}
