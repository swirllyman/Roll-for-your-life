using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	public Teleporter buddyTeleporter;

	public void SetBuddy()
	{
		isBuddy = true;
	}
	void OnTriggerEnter(Collider ball)
	{
		if (!this.isBuddy) {
			buddyTeleporter.SetBuddy();
			ball.transform.position = buddyTeleporter.transform.position;
		}
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool isBuddy = false;
}
