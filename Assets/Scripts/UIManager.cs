using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public PlaceableObject windMill;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetWindMill()
	{
		PlaceableObject p = (PlaceableObject)Instantiate (windMill, new Vector3 (1000, 1000, 1000), transform.rotation);
		GetComponent<Placement>().currentObject = p;
	}

	public void StartButtonClicked() {
		GameManager.StartGame ();
	}
}
