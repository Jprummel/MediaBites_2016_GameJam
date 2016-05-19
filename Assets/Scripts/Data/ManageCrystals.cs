using UnityEngine;
using System.Collections;

public class ManageCrystals : MonoBehaviour {

    private CheckCrystals _crystalManager;
	// Use this for initialization
	void Start () {
        _crystalManager = GameObject.Find("Main Camera").GetComponent<CheckCrystals>();
	}
	
	// Update is called once per frame
	void Update () {
	    
    }

    void AddCrystal()
    {
        _crystalManager.Add(this.gameObject);
    }

    void RemoveCrystal()
    {
        _crystalManager.Remove(this.gameObject);
    }
}
