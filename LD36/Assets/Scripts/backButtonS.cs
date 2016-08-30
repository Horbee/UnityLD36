using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backButtonS : MonoBehaviour {

	public Sprite bgSrpite;
	public GameObject menuBG;
	public GameObject menuTitle;
	public GameObject menuButtons;

	SpriteRenderer menuBGRenderer;

	SpriteRenderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		menuBGRenderer = menuBG.GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {
		rend.color = Color.green;
	}

	void OnMouseExit() {
		rend.color = Color.white;
	}

	void OnMouseUp(){
		menuBGRenderer.sprite = bgSrpite;
		menuTitle.SetActive(true);
		menuButtons.SetActive(true);
		gameObject.SetActive (false);
	}
}
