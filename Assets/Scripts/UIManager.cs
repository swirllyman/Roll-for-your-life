using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public PlaceableObject windMill;

	public Text levelTimeUI;
	public Text levelFinishUI;
	public Text FinishedUI;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		levelTimeUI.text = "Time Left: "+ GameState.Instance.timer.ToString("F1");
		if(GameState.Instance.victory)
		{
			FinishedUI.gameObject.SetActive(true);
			levelFinishUI.text = "You have won!\nYour score : " +(GameState.Instance.timer*100/GameState.Instance.windmillAmount*(GameState.Instance.zombieTakedowns + 1)).ToString("F0");
		}
		else if(GameState.Instance.failure)
		{
			FinishedUI.gameObject.SetActive(true);
			levelFinishUI.text = "You have failed!";
		}
	}

	public void SetWindMill() {
		PlaceableObject p = (PlaceableObject)Instantiate (windMill, new Vector3 (1000, 1000, 1000), transform.rotation);
		GetComponent<Placement>().currentObject = p;
	}

	public void StartButtonClicked() {
		GameManager.StartGame ();
	}

	public void ResetButtonClicked() {
		GameManager.RestartLevel ();
	}

	public void LevelSelectClicked()
	{
		Application.LoadLevel ("Level Select");
	}
}
