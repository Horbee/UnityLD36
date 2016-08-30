using UnityEngine;
using System.Collections;

public class doorItem : MonoBehaviour {

	playerController pc;
	BoxCollider2D collider;
	public GameObject emeraldParticles;
	AudioSource audioS;
	cameraShaek shake;
	// Use this for initialization
	void Start () {
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerController> ();
		collider = gameObject.GetComponent<BoxCollider2D> ();
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraShaek>();
		audioS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pc.GetDashItems() > 0 && pc.GetDashing ()) {
			collider.isTrigger = true;
		} else {
			collider.isTrigger = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			audioS.Play();
			pc.RemoveDashItems ();
			Instantiate (emeraldParticles, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
			shake.enabled = true;
			Destroy (gameObject);
		}
	}

}
