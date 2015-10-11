using UnityEngine;
using System.Collections;

public class GameState : Singleton<GameState> {
	protected GameState () {} // guarantee this will be always a singleton only - can't use the constructor!
	public int windmillAmount;
	public int zombieTakedowns;
	public float timer = 30.0f;
	public int levelNum = 0;
	public float score;

	public bool victory = false;
	public bool failure = false;
	public bool levelStart = false;

	// Update is called once per frame
	void Update () {
		if(victory)
		{
			levelStart = false;
			score = (GameState.Instance.timer*100/GameState.Instance.windmillAmount*(GameState.Instance.zombieTakedowns + 1));
			Master.scores[levelNum, 0] = (int)score;
		}
		else if(failure)
		{
			levelStart = false;
		}
		if(levelStart){
			if(timer > 0.0f)
				timer -= Time.deltaTime;
			if(timer <= 0.0f)
			{
				failure = true;
				levelStart = false;
			}
		}
	}
}

