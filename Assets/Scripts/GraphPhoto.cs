using UnityEngine;
using System.Collections;

public class GraphPhoto : MonoBehaviour, IGazeable {

	private Vector3 startPos;
	private Vector3 endPos;
	public string description; 	
	public float speed = 12.0f;
	public int index;
	private bool isGazedAt = false;

	GameObject camera;


	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		startPos = transform.position;
		GraphPhotoCloud graphPhotoCloud = (GraphPhotoCloud)GameObject.FindObjectOfType (typeof(GraphPhotoCloud));
		endPos = graphPhotoCloud.calculatePositionOnFibonacciSphere(this, 8.0f);
	}

	void Update () {
		float step = speed * Time.deltaTime;
		Vector3 scale = new Vector3(1.3f, 1.3f, 1.3f);
		if (isGazedAt) {
			//transform.position = Vector3.MoveTowards (transform.position, endPos, step*2);
			transform.localScale = Vector3.Lerp(Vector3.one,scale,step);
		} else {
			if(transform.position != startPos) {
				transform.position = Vector3.MoveTowards (transform.position, startPos, step);
			}
			transform.localScale = Vector3.Lerp(scale,Vector3.one,step);
		}
	}	

	public void reactToGaze() {
		isGazedAt = true;
	}

	public void endGaze() {
		isGazedAt = false;
	}
}