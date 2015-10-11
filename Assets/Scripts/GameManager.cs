using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static Camera setupCam;
	private static Camera playCam;

	// indicates if the ball is rolling
	public static bool Active = false;

	// Use this for initialization
	IEnumerator Start () {
		setupCam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		playCam = GameObject.Find ("PlayCam").GetComponent<Camera>();
		playCam.enabled = false;
		playCam.GetComponent<AudioListener>().enabled = false;
		GameManager.Active = false;

		AsyncOperation async = Application.LoadLevelAdditiveAsync("UI_Scene");
		yield return async;
		Debug.Log("Loading complete");
	}

	public static void StartGame() {
		GameManager.Active = true;
		GameState.Instance.levelStart = true;
		playCam.enabled = true;
		playCam.GetComponent<AudioListener>().enabled = true;
		playCam.GetComponent<CamFollow>().enabled = true;
		setupCam.enabled = false;
		setupCam.GetComponent<AudioListener>().enabled = false;
	}

	public static void RestartLevel() {
		GameManager.Active = false;
		Application.LoadLevel (Application.loadedLevel);
	}
}
