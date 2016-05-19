using UnityEngine;
using System.Collections;

public class rotating : MonoBehaviour {

	private bool _shouldIRotate = false;


	void OnMouseDown()
	{
		_shouldIRotate = true;
	}

	void Update()
	{
		Debug.Log (_shouldIRotate);
		if (_shouldIRotate) {
			Debug.Log ("Keep doing it");
			Rotate ();
		}
	}

	void Rotate()
	{
		Vector3 mousePos = Input.mousePosition;

		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));

		if (Input.GetMouseButtonUp(0)) 
		{
			_shouldIRotate = false;
		}
	}
}

