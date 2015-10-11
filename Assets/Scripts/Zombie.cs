using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public float maxChoiceTimer = 5.0f;
	public float choiceTimer;
	Animation anim;
	bool dead, dying;

	float speed = .02f;

	bool chillin;
	// Use this for initialization
	void Start () {
		dead = false;
		dying = false;
		choiceTimer = 0.0f;
		anim = GetComponent<Animation>();
		anim["death03"].layer = 2;
		anim["dead"].layer = 3;
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.up != Vector3.up)
		{
			transform.up = Vector3.up;
		}

		if(dying){
			anim.Play("death03");
		}
		else if(dead)
		{
			anim.Play ("dead");
		}
		else{
			RaycastHit hit;
			if(Physics.Raycast(new Vector3 (transform.position.x, transform.position.y + .1f, transform.position.z), transform.forward, out hit, 1)){
				transform.Rotate (0, 180, 0);
			}
			choiceTimer -= Time.deltaTime;

			if(choiceTimer <= 0.0f){
				choiceTimer = Random.Range (maxChoiceTimer, maxChoiceTimer*2);
				if(Random.value < .66f)
				{
					transform.Rotate (0, Random.Range (0, 360), 0);
					chillin = true;
					speed = 0;
				}
				else
				{
					transform.Rotate (0, Random.Range (0, 360), 0);
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

	void OnCollisionEnter(Collision c)
	{
		if(!dead && !dying){
			if(c.collider.tag == "Player")
			{
				transform.LookAt(c.collider.transform.position, transform.up);
				dying = true;
				transform.position = new Vector3(transform.position.x, transform.position.y+.05f, transform.position.z);
				StartCoroutine(DeathTimer(anim["death03"].length));
				this.PlaySound();
			}
		}
	}

	void PlaySound()
	{
		GetComponent<AudioSource>().Play();
	}

	IEnumerator DeathTimer(float timer)
	{
		yield return new WaitForSeconds(timer);
		dead = true;
		dying = false;
	}
	
			               	

			           
}
