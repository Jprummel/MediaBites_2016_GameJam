using UnityEngine;
using System.Collections;

public class rotating : MonoBehaviour {

	bool _shouldIRotate = false;
    private SoundEffects _soundFX;

    void Start()
    {
        _soundFX = GameObject.Find("Main Camera").GetComponent<SoundEffects>();
    }

	void OnMouseDown()
	{
		_shouldIRotate = true;
	}

	void Update()
	{
		if (_shouldIRotate) {
			Rotate ();
		}
	}

	void Rotate()
	{
        _soundFX.PlaySound(2);
		Vector3 mousePos = Input.mousePosition;
		Quaternion qTo;
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg - 110f;

		qTo = Quaternion.AngleAxis (angle, Vector3.forward);

		transform.rotation = qTo;

		if (Input.GetMouseButtonUp(0)) 
		{
			_shouldIRotate = false;
		}
	}
}

