using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

	public float pushAmount = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerStay(Collider c)
	{
		if(c.tag == "Player"){
			c.attachedRigidbody.AddForce(transform.forward * pushAmount);
		}
	}
}
