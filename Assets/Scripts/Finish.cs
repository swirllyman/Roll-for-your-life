using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	private bool won;
	// Use this for initialization
	void Start () {
		won = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player" &! won){
			won = true;
			GameState.Instance.victory = true;
			this.PlaySound();
		}
	}

	void PlaySound()
	{
		GetComponent<AudioSource>().Play();
	}

}
