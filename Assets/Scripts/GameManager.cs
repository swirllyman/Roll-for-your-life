using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static Camera setupCam;
	public static Camera playCam;

	// indicates if the ball is rolling
	public static bool Active = false;

	// Use this for initialization
	IEnumerator Start () {
		setupCam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		playCam = GameObject.Find ("PlayCam").GetComponent<Camera>();
		playCam.enabled = false;
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
		playCam.enabled = true;
		setupCam.enabled = false;
	}

	public static void RestartLevel() {
		GameManager.Active = false;
		Application.LoadLevel (Application.loadedLevel);
	}
}
