using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {

	private float moveSpeed = 5f;
	private float translateSpeed = 100.0f;
	Camera cam;
	// Use this for initialization
	void Start () 
	{
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && cam.orthographicSize - moveSpeed > 10) 
		{
			cam.orthographicSize -= moveSpeed;
		}
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0) 
		{
			cam.orthographicSize += moveSpeed;
		}
		if (Input.GetAxis ("Horizontal") > 0) 
		{
			transform.Translate(Vector3.right * translateSpeed * Time.deltaTime);
		}
		else if (Input.GetAxis ("Horizontal") < 0) 
		{
			transform.Translate(Vector3.left * translateSpeed * Time.deltaTime);
		}
		if (Input.GetAxis ("Vertical") > 0) 
		{
			transform.Translate(Vector3.up * translateSpeed * Time.deltaTime);
		}
		else if (Input.GetAxis ("Vertical") < 0) 
		{
			transform.Translate(Vector3.down * translateSpeed * Time.deltaTime);
		}
	}
}
