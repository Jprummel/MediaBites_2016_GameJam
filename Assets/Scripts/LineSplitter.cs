using UnityEngine;
using System.Collections;

public class LineSplitter : MonoBehaviour {

	public delegate void LazerHit(GameObject hit);
	public static event LazerHit OnLazerHit;

	public delegate void LazerLeave(GameObject hit);
	public static event LazerLeave OnlazerLeave;

	void Awake() {
		DelegateHandeler.OnLazerHit += LazerHitEvent;
		DelegateHandeler.OnlazerLeave += LazerLeaveEvent;
	}

	void OnDestroy() {
		DelegateHandeler.OnLazerHit -= LazerHitEvent;
		DelegateHandeler.OnlazerLeave -= LazerLeaveEvent;
	}

	void LazerHitEvent(GameObject hit) {

		print (hit);
		if (hit) {
			Transform[] children = hit.GetComponentsInChildren<Transform> ();

			foreach (Transform obj in children) {
				OnLazerHit (obj.gameObject);
			}
		}
	}

	void LazerLeaveEvent (GameObject hit) {
		print (hit + "Destroy");

		if (hit) {
			Transform[] children = hit.GetComponentsInChildren<Transform> ();

			foreach (Transform obj in children) {
				OnlazerLeave (obj.gameObject);
			}
		}
	}
}
