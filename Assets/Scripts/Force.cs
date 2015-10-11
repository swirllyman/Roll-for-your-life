using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

	public float pushAmount = 1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerStay(Collider c)
	{
		if(c.tag == "Player"){
			var dist = Vector3.Distance(c.gameObject.transform.position, this.transform.parent.position);
			c.attachedRigidbody.AddForce(transform.forward * pushAmount/Mathf.Pow(dist, 2));
		}
	}
}
