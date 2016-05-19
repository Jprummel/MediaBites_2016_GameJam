using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	[SerializeField] private float _speed = 3f;
	[SerializeField] private float _boundary = 30f;

	private int _theScreenWidth;
	private int _theScreenHeight;

	private Vector3 _newPos;
	private Vector3 _oldPos;
	void Start()
	{
		_newPos = transform.position;
		_theScreenWidth = Screen.width;
		_theScreenHeight = Screen.height;
	}

	void Update () 
	{

		if(Input.mousePosition.x >_theScreenWidth - _boundary)
			{
			_newPos.x += _speed * Time.deltaTime;
			}

		if(Input.mousePosition.x < 0 + _boundary)
		{
			_newPos.x -= _speed * Time.deltaTime;
		}

		if(Input.mousePosition.y > _theScreenHeight - _boundary)
		{
			_newPos.y += _speed * Time.deltaTime;
		}

		if(Input.mousePosition.y < 0 + _boundary)
		{
			_newPos.y -= _speed * Time.deltaTime;
		}
		transform.position = _newPos;
	}
}
