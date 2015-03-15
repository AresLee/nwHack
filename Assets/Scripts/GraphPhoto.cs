﻿using UnityEngine;
using System.Collections;

public class GraphPhoto : MonoBehaviour, IGazeable {

	public string description; 
	public Vector3 pointB;
	private bool isGazedAt = false;

	IEnumerator Start () {
		Vector3 pointA = transform.position;
		while (true) {
			if (isGazedAt) {
				yield return StartCoroutine (MoveObject (transform, pointA, pointB, 3.0f));
			} else {
				yield return StartCoroutine (MoveObject (transform, pointB, pointA, 3.0f));
			}
		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
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