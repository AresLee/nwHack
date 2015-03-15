using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GraphPhotoCloud : MonoBehaviour, IGazeable {

	List<GameObject> graphPhotos;
	private int sampleSize = 12;
	public float photoSpacing = 3.0f;

	void Start () {
		graphPhotos = populateGraphList ();	
	}
	
	void Update () {
	
	}

	List<GameObject> populateGraphList ()
	{
		graphPhotos = new List<GameObject> ();
		for (int i = 0; i < sampleSize; i++) {
			GameObject photo = (GameObject)Instantiate(Resources.Load("GraphPhoto"));
			photo.transform.parent = GameObject.Find ("GraphPhotoCloud").transform;
			photo.transform.position =  distributePhotosOnSphere(i, photo);
			graphPhotos.Add(photo);
		}
		return graphPhotos;
	}

	Vector3 distributePhotosOnSphere (int i, GameObject photo)
	{	
		float inc =  Mathf.PI  * (3 - Mathf.Sqrt(5));
		float off = 2 / sampleSize;
		float y = i * off - 1 + (off / 2);
		float radius = Mathf.Sqrt(1 - y*y);
		//float radius = photo.renderer.bounds.size.magnitude * maxPhotosInRow / photoSpacing;
		float phi = i * inc;
		return new Vector3((Mathf.Cos(phi)*radius), y, Mathf.Sin(phi)*radius);
	}

	Vector3 distributePhotosOnCircle (int i, GameObject photo)
	{	
		float radius = photo.renderer.bounds.size.magnitude * sampleSize / photoSpacing;
		float theta = i * 2*Mathf.PI / sampleSize;
		Vector3 pos = new Vector3();
		pos.x = transform.position.x + radius*Mathf.Sin(theta); 
		pos.y = transform.position.y;
		pos.z = transform.position.z + radius*Mathf.Cos(theta); 
		return pos;
	}

	public void reactToGaze() {
		//isGazedAt = true;
	}
	
	public void endGaze() {
		//isGazedAt = false;
	}
}
