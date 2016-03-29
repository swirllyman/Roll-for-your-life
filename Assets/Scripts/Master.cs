using UnityEngine;
using System.Collections;

public class Master : MonoBehaviour {

	//Level number, highest score
	public static int[,] scores = new int[35, 2];
    public GameObject sound;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
        //Instantiate(sound);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
