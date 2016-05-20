using UnityEngine;
using System.Collections;

public class ManageCrystals : MonoBehaviour {

    private CheckCrystals _crystalManager;
    private PointingLineRenderer _pointRenderer;
    private CheckCrystals _checkCrystals;
	// Use this for initialization
	void Start () {
        
        
        _pointRenderer = GetComponent<PointingLineRenderer>();
        _checkCrystals = GameObject.Find("Main Camera").GetComponent<CheckCrystals>();
        _crystalManager = GameObject.Find("Main Camera").GetComponent<CheckCrystals>();
	}
	
	// Update is called once per frame
	void Update () {
	    
    }

    public void AddCrystal()
    {
            _crystalManager.Add(this.gameObject);
    }

    public void RemoveCrystal()
    {
            _crystalManager.Remove(this.gameObject);
            _checkCrystals.CheckLitCrystals();        
    }
}
