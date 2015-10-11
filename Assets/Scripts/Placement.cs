using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour {

	//This will be our "current" object. The one that is being dragged/rotated.
	public PlaceableObject currentObject;

	//This bool is true when our current object has been placed.
	private bool placed;

	// Use this for initialization
	void Start () {
		placed = false;
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
}
