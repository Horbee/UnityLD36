using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameEnding : MonoBehaviour {

	Fading fading;
	// Use this for initialization
	void Start () {
		fading = GameObject.Find ("ScreenFader").GetComponent<Fading> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			StartCoroutine (ChangeLevel ());
		}
	}

	IEnumerator ChangeLevel(){
		fading.BeginFade (1);
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (0); //menu
	}

}
