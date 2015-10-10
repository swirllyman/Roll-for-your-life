using UnityEngine;
using System.Collections;

public class WindMill : PlaceableObject {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Go()
	{
		//Change the material to a solid
		//GetComponent<Renderer>().material = windmillMatSolid;
		
		//Turn on the force in the child object
		transform.GetChild (0).gameObject.SetActive (true);

		//selectedObject = (GameObject)Instantiate(windmill, new Vector3(-10000, 5000, 5000), Quaternion.identity);
	}
}
