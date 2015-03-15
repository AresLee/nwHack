using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GraphPhotoCloud : MonoBehaviour {

	List<GameObject> graphPhotos;
	private int maxPhotosInRow = 12;

	// Use this for initialization
	void Start () {
		graphPhotos = populateGraphList ();
			//new List<GraphPhoto> ();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	List<GameObject> populateGraphList ()
	{
		graphPhotos = new List<GameObject> ();
		for (int i = 0; i < maxPhotosInRow; i++) {
			GameObject photo = (GameObject)Instantiate(Resources.Load("GraphPhoto"));
			photo.transform.parent = GameObject.Find ("GraphPhotoCloud").transform;
			photo.transform.position =  positionAroundCircle(i, photo); //new Vector3(i*photo.renderer.bounds.size.x,0,-7);
			graphPhotos.Add(photo);
		}
		return graphPhotos;
	}

	Vector3 positionAroundCircle (int i, GameObject unit)
	{	
		float radius = unit.renderer.bounds.size.magnitude * maxPhotosInRow / 2;
		float angle = i * 2*Mathf.PI / maxPhotosInRow;
		Vector3 pos = new Vector3();
		pos.x = transform.position.x + radius*Mathf.Sin(angle); 
		pos.y = transform.position.y;
		pos.z = transform.position.z + radius*Mathf.Cos(angle); 
		return pos;
	}
}
