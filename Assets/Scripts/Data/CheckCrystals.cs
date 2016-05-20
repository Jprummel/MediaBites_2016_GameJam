using UnityEngine;
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

    public void CheckLitCrystals()
    {
        if (_crystals.Count == 0)
        {
            //WinLevel function
            _levelEnd.LevelWin();
        }
    }

    public void Add(GameObject crystal)
    {
        if (!_crystals.Contains(crystal))
        {
            _crystals.Add(crystal);
        }
    }

    public void Remove(GameObject crystal)
    {
        _crystals.Remove(crystal);

        if (_crystals.Count == 0)
        {
            //WinLevel function
            _levelEnd.LevelWin();
        }
    }
}
