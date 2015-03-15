using UnityEngine;
using System.Collections;

public class Gaze : MonoBehaviour {

	public RaycastHit raycastHit;
	public GameObject gameObjectHit;
	public IGazeable lastGazeable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics.Raycast(transform.position, transform.forward, out raycastHit, 1000.0f)) 
		{
			Collider raycastHitCollider = raycastHit.collider;
			gameObjectHit = raycastHit.transform.gameObject;

//			Debug.Log("You hit something"+raycastHit.ToString());
//			Debug.Log(transform.position-raycastHitCollider.transform.position);

			IGazeable gazeable = 
				raycastHitCollider.gameObject.GetComponent(typeof(IGazeable)) as IGazeable;
			if (gazeable != null) {
				if (gazeable != lastGazeable) {
					gazeable.reactToGaze();
					if(lastGazeable != null){lastGazeable.endGaze();}
				}
			}
			lastGazeable = gazeable;
		}
		else
		{
//			Debug.Log("Yo dude, we didn't hit anything!");
		}
	}
}
