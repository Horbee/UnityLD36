using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playButtonS : MonoBehaviour {

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
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); //restart
	}
}
