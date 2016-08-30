using UnityEngine;
using System.Collections;

public class jumpBtn : MonoBehaviour {
	bool touched;

	void OnMouseDown() {
		touched = true;
	}

	void OnMouseUp(){
		touched = false;
	}

	public bool getTouched(){
		return touched;
	}
}
