using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CrystalData : MonoBehaviour {

    [SerializeField]private List<GameObject>    _crystals;
    [SerializeField]private Text                _crystalsLeft;
                    private LevelEnd            _levelEnd;
                    private SoundEffects        _soundFX;


	// Use this for initialization
	void Start () {
        _levelEnd = GetComponent<LevelEnd>();
        _soundFX = GetComponent<SoundEffects>();
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
		if (!_crystals.Contains (crystal)) {
			_soundFX.PlaySound(0);
			_crystals.Add (crystal);
			_crystalsLeft.text = "Crystals left : " + _crystals.Count.ToString ();
        }
        else
        {
            _levelEnd.LevelLose(2);
        }
    }

	public bool checkForCrystals(GameObject crystal)
	{
		if (_crystals.Contains (crystal)) {
			return true;
		} else {
			return false;
		}
	}
    public void Remove(GameObject crystal)
    {
		if(!_crystals.Contains(crystal))
        {
            _soundFX.PlaySound(3);
			_levelEnd.LevelLose (3);
		}

        _soundFX.PlaySound(1);
        _crystals.Remove(crystal);
        _crystalsLeft.text = "Crystals left : " + _crystals.Count.ToString();
        if (_crystals.Count == 0)
        {
            //WinLevel function
            _levelEnd.LevelWin();
        }
    }
}
