﻿using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, -0.1f);
	}
}
