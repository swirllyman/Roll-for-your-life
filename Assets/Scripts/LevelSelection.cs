using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public Text[] scores;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < scores.Length; i++){
			scores[i].text = "High Score: "+Master.scores[i, 0].ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartLevel(string levelName)
	{
		Application.LoadLevel (levelName);
	}
}
