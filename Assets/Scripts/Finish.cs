using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			GameState.Instance.victory = true;
			this.PlaySound();
		}
	}

	void PlaySound()
	{
		GetComponent<AudioSource>().Play();
	}

}
