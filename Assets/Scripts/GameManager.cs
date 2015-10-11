using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// indicates if the ball is rolling
	public static bool Active = false;

	// Use this for initialization
	IEnumerator Start () {
		GameManager.Active = false;

		AsyncOperation async = Application.LoadLevelAdditiveAsync("UI_Scene");
		yield return async;
		Debug.Log("Loading complete");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void StartGame() {
		GameManager.Active = true;
	}

	public void EndGame() {
		GameManager.Active = false;
	}
}
