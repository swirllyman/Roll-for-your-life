using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static GameManager GM;
	// Use this for initialization
	IEnumerator Start () {
		AsyncOperation async = Application.LoadLevelAdditiveAsync("UI_Scene");
		yield return async;
		Debug.Log("Loading complete");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
