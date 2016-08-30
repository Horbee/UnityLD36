using UnityEngine;
using System.Collections;

public class dashItem : MonoBehaviour {

	playerController pc;

	float floatAmount = 0.5f;
	bool down = true;
	float origY;
	Vector2 pos;

	// Use this for initialization
	void Start () {
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerController> ();
		origY = transform.position.y;
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (down) {
			pos.y -= floatAmount * Time.deltaTime;
		} else {
			pos.y += floatAmount * Time.deltaTime;
		}

		transform.position = pos;

		if (transform.position.y < (origY - 0.25f)) {
			down = false;
		}

		if (transform.position.y > (origY + 0.25f)) {
			down = true;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			pc.AddDashItems ();
			Destroy (gameObject);
		}
	
	}
}
