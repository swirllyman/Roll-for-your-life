using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public float maxChoiceTimer = 5.0f;
	public float choiceTimer;
	Animation anim;

	float speed = .02f;

	bool chillin;
	// Use this for initialization
	void Start () {
		choiceTimer = maxChoiceTimer;
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		choiceTimer -= Time.deltaTime;

		if(choiceTimer <= 0.0f){
			choiceTimer = maxChoiceTimer;
			if(Random.value > .66f)
			{
				transform.Rotate (0, Random.Range (0, 360), 0);
				chillin = true;
				speed = 0;
			}
			else
			{
				chillin = false;
				speed = .02f;
			}
		}

		if(!chillin){
			transform.Translate(Vector3.forward * speed);
		}


		if(chillin){
			anim.CrossFade("idle02");
		}
		else
		{
			anim.CrossFade("walk03");
		}
	}
}
