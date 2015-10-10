using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour {

//	//You can set public objects in the inspector
//	public GameObject windmill;
//	public Material windmillMatSolid;

	//You can set private objects in the Start Method
	private Transform player;

	//This will be our "current" object. The one that is being dragged/rotated.
	public PlaceableObject currentObject;

	//This bool is true when our current object has been placed.
	private bool placed;


	//This will get moved to the master script once written.
	//Starting the games will be controlled by that
	private bool started;


	// Use this for initialization
	void Start () {
		//It is ok to run a Find() method at the start
		//DO NOT do find's at runtime. Extremely inefficient
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		placed = false;
		started = false;
//		if(windmill == null)
//		{
//			Debug.Log ("This will give us output in our console log.");
//			Debug.LogError("This will throw an error at us.");
//		}
	}
	
	// Update is called once per frame
	void Update () {
		if(currentObject != null)
		{
			//Returns a ray going from camera through a screen point.
			//Input.mousePosition gives us our current mouse position in pixel coordinates
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			//This object will allow us to get information on the collider our ray hits.
			RaycastHit hit;

			//This if statement will only execute if the raycast hits into something
			if(Physics.Raycast (ray, out hit)){

				//If our mouse is over a platform
				if(hit.collider.tag == "Platform")
				{
					if(!placed)
						currentObject.transform.position = hit.point;

					if(Input.GetMouseButtonDown(0)){
						placed = true;
						currentObject.GetComponent<PlaceableObject>().isPlaced = true;
					}

					if(Input.GetMouseButtonUp(0)){
						currentObject = null;
						placed = false;
					}
				}
			}
			else
			{
				if(Input.GetMouseButtonDown (0))
				{
					Destroy(currentObject);
				}
			}
		}
	}


//	//This is our GUI function. The bulk of our GUI will be placed in this method
//	void OnGUI()
//	{
//		//This is a simple button in unity
//		if(GUI.Button(new Rect(25, 150, 75, 50), "Basic\nWindmill"))
//		{
//			placed = false;
//
//			//Set out curernt object as a transparent windmill
//			currentObject = (GameObject)Instantiate(windmill, new Vector3(-10000, 5000, 5000), Quaternion.identity);
//		}
//
//		//This is a simple button in unity
//		if(GUI.Button(new Rect(25, 210, 75, 50), "Basic\nWindmill"))
//		{
//			placed = false;
//			
//			//Set out curernt object as a transparent windmill
//			currentObject = (GameObject)Instantiate(windmill, new Vector3(-10000, 5000, 5000), Quaternion.identity);
//		}
//
//
//		//This is a simple button in unity
//		if(GUI.Button(new Rect(25, 270, 75, 50), "Basic\nWindmill"))
//		{
//			placed = false;
//			
//			//Set out curernt object as a transparent windmill
//			currentObject = (GameObject)Instantiate(windmill, new Vector3(-10000, 5000, 5000), Quaternion.identity);
//		}
//
//
//		//This is a simple button in unity
//		if(GUI.Button(new Rect(25, 330, 75, 50), "Basic\nWindmill"))
//		{
//			placed = false;
//			
//			//Set out curernt object as a transparent windmill
//			currentObject = (GameObject)Instantiate(windmill, new Vector3(-10000, 5000, 5000), Quaternion.identity);
//		}
//
//
//		if(!started){
//			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height-75, 100, 50), "Start"))
//			{
//				//This will allow force to effect the player
//				player.GetComponent<Rigidbody>().isKinematic = false;
//				
//				started = true;
//
//			}
//		}
//	}
}
