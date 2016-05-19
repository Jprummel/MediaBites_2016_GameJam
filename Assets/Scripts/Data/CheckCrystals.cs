﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckCrystals : MonoBehaviour {
    [SerializeField]private List<GameObject> _crystals;
                    private LevelEnd _levelEnd;

	// Use this for initialization
	void Start () {
        _levelEnd = GetComponent<LevelEnd>();

        _crystals = new List<GameObject>();
        foreach (GameObject crystal in GameObject.FindGameObjectsWithTag("Crystal"))
        {
            _crystals.Add(crystal);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CheckLitCrystals()
    {
        if (_crystals.Count == 0)
        {
            //WinLevel function
            _levelEnd.LevelWin();
        }
    }
}