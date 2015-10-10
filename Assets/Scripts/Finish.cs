using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	bool victory;

	// Use this for initialization
	void Start () {
		victory = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			victory = true;
		}
	}


	void OnGUI()
	{
		if(victory){
			GUI.Box (new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200), "You win!");
			if(GUI.Button (new Rect(Screen.width / 2 - 50, Screen.height / 2 + 125, 100, 65), "Main\nmenu"))
			{
				Application.LoadLevel ("Main Menu");
			}
		}
	}
}
