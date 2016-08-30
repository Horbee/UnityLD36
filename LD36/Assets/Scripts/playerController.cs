using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

	public GameObject dashButton;

	public AudioClip death, jump, dashWav, explosion, pickup;
	AudioSource audioS;

	public float maxSpeed = 8f;
	public float moveForce = 100;

	Rigidbody2D rb;
	bool facingRight = true; 

	bool grounded = false;
	//float groundCheckRadius = 0.1f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;
	public float dashForce;
	public float maxDash = 1;
	float dash;
	bool dashing = false;

	public Slider dashSlider;
	public Text itemText;

	int dashItems;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		dash = maxDash;
		dashSlider.maxValue = maxDash;
		dashSlider.value = dash;
		itemText.text = "Items: " + dashItems;
		audioS = GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetKey ("escape"))
			SceneManager.LoadScene (0);
	
	}
	

	void FixedUpdate () {
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (grounded && (Input.GetAxis ("Jump")>0 || Input.GetMouseButtonDown(0))) {
			grounded = false;
			rb.AddForce (new Vector2 (0, jumpHeight));
			audioS.clip = jump;
			audioS.Play();
		}

		float h = Input.GetAxis ("Horizontal");
		//float h = Input.acceleration.x;

		if (h * rb.velocity.x < maxSpeed)
			//rb.velocity = new Vector2(h * 8, rb.velocity.y);
			rb.AddForce (Vector2.right * h * moveForce);
		
		if (Mathf.Abs (rb.velocity.x) > maxSpeed)
		 	rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);

	//	rb.velocity = new Vector2(h * 5, rb.velocity.y);

		playerDash (h);

		//if (isInBoundsDashButton (Input.GetTouch().position.x, Input.GetTouch().position.y))
		//	Debug.Log ("Correct!");
	//	Input.GetTouch ().position == dashButton.transform.position;


		if (h < 0 && facingRight) {
			flip ();
		} else if (h > 0 && !facingRight) {
			flip ();
		}

	}

	public void playerDash(float h){
		dashSlider.value = dash;

		float x = Input.GetTouch (0).position.x;
		float y = Input.GetTouch (0).position.y;

		//ANDROID
		if (isInBoundsDashButton (x, y) && dash > 0) {
			dashing = true;
			dash -= Time.deltaTime;
			//rb.AddForce (new Vector2 (h * dashForce, 0));
			rb.AddForce (Vector2.right * h * dashForce);
			audioS.clip = dashWav;
			audioS.Play();
		} else {
			dashing = false;
		}

		//PC
	/*	if (Input.GetAxis ("Fire1") > 0 && dash > 0) {
			dashing = true;
			dash -= Time.deltaTime;
			//rb.AddForce (new Vector2 (h * dashForce, 0));
			rb.AddForce (Vector2.right * h * dashForce);
			audioS.clip = dashWav;
			audioS.Play();
		} 
		if(Input.GetAxis ("Fire1") == 0 ) {
			dashing = false;
		}*/


		if (!dashing && dash < maxDash)
			dash+= 0.02f;
	}

	bool isInBoundsDashButton(float x, float y){
		bool horiz = (x > dashButton.transform.position.x && x < dashButton.transform.position.x + 200);
		bool vert = (y > dashButton.transform.position.y && y < dashButton.transform.position.y + 100);
		return (horiz && vert);
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	
	}

	public void AddDashItems(){
		dashItems++;
		itemText.text = "Items: " + dashItems;
		audioS.clip = pickup;
		audioS.Play();
	}

	public void RemoveDashItems(){
		dashItems--;
		itemText.text = "Items: " + dashItems;
	}

	public int GetDashItems(){
		return dashItems;
	}

	public bool GetDashing(){
		return dashing;
	}
}
