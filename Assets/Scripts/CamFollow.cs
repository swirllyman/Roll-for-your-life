using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public Rigidbody body;
	
	public float damping;

	private float height;

	private float startingXRot;
	public Transform target;
	Quaternion targetRotation;

	private float currentDistance = 0;

	private Vector3 lastDirection;


	// Use this for initialization
	void Start () {
		startingXRot = transform.rotation.x;
		height = transform.position.y;
		currentDistance = Vector3.Distance(target.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position;
		targetRotation = Quaternion.LookRotation(body.velocity.normalized, Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * damping);
		transform.position -= transform.forward * currentDistance;
		transform.position = new Vector3(transform.position.x, height, transform.position.z);
		transform.LookAt (target.position);
		//transform.position = new Vector3(transform.position.x, height, transform.position.z - currentDistance);
		//transform.LookAt (target.position);
	}
}
