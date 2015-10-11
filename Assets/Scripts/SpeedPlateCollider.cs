using UnityEngine;
using System.Collections;

public class SpeedPlateCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider ball)
	{
		ball.attachedRigidbody.AddForce(transform.forward * pushAmount);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private const float pushAmount = 1000;
}
