using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static Camera setupCam;
	private static Camera playCam;

	private GameObject player;

	// indicates if the ball is rolling
	public static bool Active = false;

	// Use this for initialization
	IEnumerator Start () {
		// initialize cameras
		setupCam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		playCam = GameObject.Find ("PlayCam").GetComponent<Camera>();
		playCam.enabled = false;
		playCam.GetComponent<AudioListener>().enabled = false;

		// find the spawnpoint. if it exists create a player and put it there.
		GameObject spawnPoint = GameObject.Find ("SpawnPoint");
		if (null != spawnPoint) {
			Transform spawnPointTransform = GameObject.Find ("SpawnPoint").GetComponent<Transform> ();
			this.player = (GameObject)Instantiate(Resources.Load ("BubbleBoy"));
			Rigidbody playerBody = player.GetComponent<Rigidbody> ();
			playerBody.position = spawnPointTransform.position;
			playerBody.velocity = Vector3.zero;

			CamFollow follow = playCam.GetComponentInParent<CamFollow> ();
			follow.target = this.player.transform;
			follow.body = playerBody;
		} else {
			Debug.LogWarning ("Failed to get spawnpoint");
		}

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
