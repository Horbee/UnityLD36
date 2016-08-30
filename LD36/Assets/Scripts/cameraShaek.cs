using UnityEngine;
using System.Collections;

public class cameraShaek : MonoBehaviour {

	Transform camTransform;
	public float shakeDuration = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	// Use this for initialization
	void Awake() {
		camTransform = GetComponent (typeof(Transform)) as Transform;
	}

	void OnEnable(){
		originalPos = camTransform.localPosition;
	}


	// Update is called once per frame
	void Update () {
		if (shakeDuration > 0) {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime * decreaseFactor; 
		} else {
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
			this.enabled = false;
		}


	}
}
