using UnityEngine;
using System.Collections;

public class GraphPhoto : MonoBehaviour, IGazeable {

	private Vector3 startPos;
	public Vector3 endPos;
	public string description; 	
	public float speed = 12.0f;
	private bool isGazedAt = false;

	void Start () {
		startPos = transform.position;
	}

	void Update () {
		float step = speed * Time.deltaTime;
		if (isGazedAt) {
			transform.position = Vector3.MoveTowards (transform.position, endPos, step);
		} else {
			if(transform.position != startPos) {
				transform.position = Vector3.MoveTowards (transform.position, startPos, step);
			}
		}
	}	

	public void reactToGaze() {
		isGazedAt = true;
	}

	public void endGaze() {
		isGazedAt = false;
	}
}