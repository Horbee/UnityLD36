using UnityEngine;
using System.Collections;

public class QutiButtonS : MonoBehaviour {

	SpriteRenderer rend;
	AudioSource source;
	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {
		rend.color = Color.green;
		source.Play ();
	}

	void OnMouseExit() {
		rend.color = Color.white;
	}

	void OnMouseUp(){
		Application.Quit();
	}
}
