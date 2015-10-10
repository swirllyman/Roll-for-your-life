﻿using UnityEngine;
using System.Collections;

public enum PlaceableObjectType {windmill, missle}

public class PlaceableObject : MonoBehaviour {

	public Material solidMat;

	public PlaceableObjectType currentObject;

	public bool isPlaced = false;
	public bool finished = false;
	// Use this for initialization
	void Start () {
		finished = false;
		isPlaced = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Returns a ray going from camera through a screen point.
		//Input.mousePosition gives us our current mouse position in pixel coordinates
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		//This object will allow us to get information on the collider our ray hits.
		RaycastHit hit;
		
		//This if statement will only execute if the raycast hits into something
		if(Physics.Raycast (ray, out hit)){
			
			//If our mouse is over a platform
			if(hit.collider.tag == "Platform"){

				if(currentObject == PlaceableObjectType.windmill){
					if(Input.GetMouseButton(0) &! finished){
						transform.LookAt (hit.point, transform.up);
					}

					if(Input.GetMouseButtonUp(0)){
						GetComponent<Renderer>().material = solidMat;
						finished = true;

						GetComponent<Collider>().enabled = true;
						
						//Turn on the force in the child object
						transform.GetChild(0).gameObject.SetActive(true);

					}

				}

				if(currentObject == PlaceableObjectType.missle){
					if(Input.GetMouseButtonDown(0)){

					}
				}
			}
			else if(hit.collider.gameObject == gameObject){
				Debug.Log ("Over a windmill");
				if(Input.GetMouseButtonDown(0)){
					Destroy (hit.collider.gameObject);
				}
			}
		}
	}
}
