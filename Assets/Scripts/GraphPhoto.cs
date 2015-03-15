using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class GraphPhoto : MonoBehaviour, IGazeable {

	private Vector3 startPos;
	private Vector3 endPos;
	public string description; 	
	public float speed = 12.0f;
	public int index;
	private bool isGazedAt = false;
	public GameObject myo = null;
	private Pose _lastPose = Pose.Unknown;
	GameObject camera;



	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		myo = GameObject.FindGameObjectWithTag ("Myo");
		startPos = transform.position;
		GraphPhotoCloud graphPhotoCloud = (GraphPhotoCloud)GameObject.FindObjectOfType (typeof(GraphPhotoCloud));
		endPos = graphPhotoCloud.calculatePositionOnFibonacciSphere(this, 8.0f);
	}

	void Update () {
		float step = speed * Time.deltaTime;
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a fist is made.
			if (thalmicMyo.pose == Pose.Fist) {
				thalmicMyo.Vibrate (VibrationType.Medium);
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
				
			} else if (thalmicMyo.pose == Pose.WaveIn) {
				if (isGazedAt) {
					//transform.position = Vector3.MoveTowards (transform.position, endPos, step*2);
					transform.position =  endPos;
				}

				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.WaveOut) {
				if(transform.position != startPos) {
					//transform.position = Vector3.MoveTowards (transform.position, startPos, step);
					transform.position =  startPos;
				}
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.DoubleTap) {

				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			}
		}
		
		if (isGazedAt) {
			transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
		} else {
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}	

	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.
    void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard) {
            myo.Unlock (UnlockType.Timed);
        }

        myo.NotifyUserAction ();
    }

	public void reactToGaze() {
		isGazedAt = true;
	}

	public void endGaze() {
		isGazedAt = false;
	}
}