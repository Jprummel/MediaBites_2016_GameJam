using UnityEngine;
using System.Collections;

public class Rotate: MonoBehaviour {
    [SerializeField]
    private float speed;
	// Use this for initialization
	void Start () {
        speed = Random.Range(-20, 20);
        speed /= 10f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, speed);
	}
}
