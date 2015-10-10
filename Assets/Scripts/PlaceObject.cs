using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {

	public PlaceableObject selectedObject;
	bool placed = false;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (selectedObject != null) 
		{
			//Returns a ray going from camera through a screen point.
			//Input.mousePosition gives us our current mouse position in pixel coordinates
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
			//This object will allow us to get information on the collider our ray hits.
			RaycastHit hit;
		
			//This if statement will only execute if the raycast hits into something
			if (Physics.Raycast (ray, out hit)) {
			
				//If our mouse is over a platform
				if (hit.collider.tag == "Platform") 
				{
					if (Input.GetMouseButtonDown (1)) 
					{
						Destroy (selectedObject);
					}

					if(!placed)
						selectedObject.transform.position = hit.point;
				
					//Mouse Drag
					if (Input.GetMouseButton (0)) 
					{		
						placed = true;
						//This will make our current object face towards our hit point
						selectedObject.transform.LookAt (hit.point, transform.up);
					}
				
					if (Input.GetMouseButtonUp (0)) 
					{
						selectedObject.Go();
						selectedObject = null;
						placed = false;
					}
				}
			}
		}
	}


}
