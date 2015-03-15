using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GraphPhotoCloud : MonoBehaviour, IGazeable {

	List<GameObject> graphPhotos;
	private int sampleSize = 24;
	private float photoSpacing = 11.0f;

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
			photo.transform.position =  distributePhotosOnFibonacciSphere(i, photo);
			graphPhotos.Add(photo);
		}
		return graphPhotos;
	}

	Vector3 distributePhotosOnFibonacciSphere (int i, GameObject photo)
	{	
		float rnd = 1.0f;
		//float rnd = Random.value() * sampleSize;
		float inc =  Mathf.PI  * (3.0f - Mathf.Sqrt(5.0f));
		float off = 2.0f / sampleSize;
		float y = i * off - 1.0f + (off / 2.0f);
		float radius = Mathf.Sqrt(1.0f - y*y);
		float phi = ((i + rnd) % sampleSize) * inc;
		float scale = photo.renderer.bounds.size.magnitude * sampleSize / photoSpacing;
		return new Vector3((Mathf.Cos(phi)*radius), y, Mathf.Sin(phi)*radius)*scale;

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
