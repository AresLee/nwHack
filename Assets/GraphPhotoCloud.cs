using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
			photo.transform.position = new Vector3(i*photo.renderer.bounds.size.x,0,-7);
			graphPhotos.Add(photo);
		}
		return graphPhotos;
	}
}
