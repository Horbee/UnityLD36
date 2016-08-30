using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class helpButtonS : MonoBehaviour {

	public Sprite helpSprite;
	public GameObject menuBG;
	public GameObject menuTitle;
	public GameObject menuButtons;
	public GameObject backButton;

	SpriteRenderer menuBGRenderer;
	SpriteRenderer rend;
	AudioSource source;
	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		menuBGRenderer = menuBG.GetComponent<SpriteRenderer>();
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
		menuBGRenderer.sprite = helpSprite;
		menuTitle.SetActive(false);
		menuButtons.SetActive(false);
		backButton.SetActive (true);
	}
}
