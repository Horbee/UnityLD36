using UnityEngine;
using System.Collections;

public class playerFollow : MonoBehaviour {

	public Transform player;
	public float smoothness;

	Vector3 offset;

	float lowestY;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;

		lowestY = transform.position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPos = player.position + offset;

		transform.position = Vector3.Lerp (transform.position, targetPos, smoothness * Time.deltaTime);

		if (transform.position.y < lowestY)
			transform.position = new Vector3(transform.position.x, lowestY, transform.position.z);
	}
}
