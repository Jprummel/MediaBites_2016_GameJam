﻿using UnityEngine;
using System.Collections;

public class LineSplitter : MonoBehaviour {

	public delegate void LazerHit(GameObject hit);
	public static event LazerHit OnLazerHit;

	public delegate void LazerLeave(GameObject hit);
	public static event LazerLeave OnlazerLeave;

	private CrystalData _crystalData;
	private LevelEnd _levelEnd;

	void Awake() {
		_crystalData = GameObject.Find("Main Camera").GetComponent<CrystalData>();
		_levelEnd = GameObject.Find ("Main Camera").GetComponent<LevelEnd> ();
		DelegateHandeler.OnLazerHit += LazerHitEvent;
		DelegateHandeler.OnlazerLeave += LazerLeaveEvent;
	}

	void OnDestroy() {
		DelegateHandeler.OnLazerHit -= LazerHitEvent;
		DelegateHandeler.OnlazerLeave -= LazerLeaveEvent;
	}

	void LazerHitEvent(GameObject hit) {

		if (hit) {
		/*	if (!_crystalData.checkForCrystals (hit)) 
			{
				Debug.Log ("Crash/bad ending");
				_levelEnd.LevelLose ();
			}*/
			Transform[] children = hit.GetComponentsInChildren<Transform> ();

			foreach (Transform obj in children) {
				if (OnLazerHit != null) 
					OnLazerHit (obj.gameObject);
			}
		}
	}
	public static void Nullify()
	{
		Debug.Log ("Ik laad een nieuwe scene");
		OnLazerHit = null;
		OnlazerLeave = null;
	}
	void LazerLeaveEvent (GameObject hit) {
		print (hit + "Destroy");

		if (hit) {
			Transform[] children = hit.GetComponentsInChildren<Transform> ();

			foreach (Transform obj in children) {
				if (OnlazerLeave != null)
					OnlazerLeave (obj.gameObject);
			}
		}
	}
}
