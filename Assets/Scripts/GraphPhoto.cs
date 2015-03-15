using UnityEngine;
using System.Collections;

public class GraphPhoto : MonoBehaviour, IGazeable {

	public string description; 
	public Vector3 pointB;
	private bool isGazedAt = false;

	void Start () {
		Vector3 pointA = transform.position;
			if (isGazedAt) {
				MoveObject (transform, pointA, pointB, 3.0f);
			} else {
				MoveObject (transform, pointB, pointA, 3.0f);
			}
	}
	
	void MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
		}
	}

	// Update is called once per frame
	void Update () {
	}	

	public void reactToGaze() {
		isGazedAt = true;
	}

	public void endGaze() {
		isGazedAt = false;
	}
}