using UnityEngine;
using System.Collections;

public class ManageCrystals : MonoBehaviour {

    private CrystalData _crystalManager;
    private LineRendererScript _lineRenderer;
   // Use this for initialization
	void Start () 
    {        
        _lineRenderer = GetComponent<LineRendererScript>();
        _crystalManager = GameObject.Find("Main Camera").GetComponent<CrystalData>();
	}

    public void AddCrystal()
    {
            _crystalManager.Add(this.gameObject);
    }

    public void RemoveCrystal()
    {
            _crystalManager.Remove(this.gameObject);
            _crystalManager.CheckLitCrystals();        
    }
}
