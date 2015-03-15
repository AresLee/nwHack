using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GraphPhotoCloud : MonoBehaviour, IGazeable {

	List<GraphPhoto> graphPhotos;
	private int sampleSize = 24;
	private float photoSpacing = 11.0f;

	void Start () {
		graphPhotos = populateGraphList ();	
	}
	
	void Update () {
	
	}

	List<GraphPhoto> populateGraphList ()
	{
		graphPhotos = new List<GraphPhoto> ();
		for (int i = 0; i < sampleSize; i++) {
			GraphPhoto photo = Instantiate(Resources.Load("GraphPhoto", typeof(GraphPhoto))) as GraphPhoto;
			photo.index = i;
			photo.transform.parent = GameObject.Find ("GraphPhotoCloud").transform;
			float scale = photo.renderer.bounds.size.magnitude * sampleSize / photoSpacing;
			photo.transform.position =  calculatePositionOnFibonacciSphere(photo, scale);
			graphPhotos.Add(photo);
		}
		return graphPhotos;
	}

	public Vector3 calculatePositionOnFibonacciSphere (GraphPhoto photo, float scale)
	{	
		float rnd = 1.0f;
		//float rnd = Random.value() * sampleSize;
		float inc =  Mathf.PI  * (3.0f - Mathf.Sqrt(5.0f));
		float off = 2.0f / sampleSize;
		float y = photo.index * off - 1.0f + (off / 2.0f);
		float radius = Mathf.Sqrt(1.0f - y*y);
		float phi = ((photo.index + rnd) % sampleSize) * inc;
		return new Vector3((Mathf.Cos(phi)*radius), y, Mathf.Sin(phi)*radius)*scale;

	}

	public Vector3 calculatePositionOnCircle (GraphPhoto photo, float scale)
	{	
		float radius = scale;
		float theta = photo.index * 2*Mathf.PI / sampleSize;
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
