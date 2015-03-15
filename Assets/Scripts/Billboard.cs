using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	GameObject camera;
	void Start() {
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update() { 
		transform.LookAt(camera.transform.position);
		transform.rotation *= Quaternion.Euler (90, 0, 0);
	} 
}
