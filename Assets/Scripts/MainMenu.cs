using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject master;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel ("Level Select");
		Instantiate(master);
	}
}
