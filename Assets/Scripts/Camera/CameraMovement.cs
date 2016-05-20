using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	[SerializeField] private float _speed = 10f;
	[SerializeField] private float _boundary = 30f;

	private int _theScreenWidth;
	private int _theScreenHeight;

    [SerializeField]
    private float MinXPos;
    [SerializeField]
    private float MaxXPos;
    [SerializeField]
    private float MinYPos;
    [SerializeField]
    private float MaxYPos;



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
        Vector3 pos = transform.position;
		if(Input.mousePosition.x >_theScreenWidth - _boundary && pos.x < MaxXPos)
			{
			_newPos.x += _speed * Time.deltaTime;
			}

		if(Input.mousePosition.x < 0 + _boundary && pos.x > MinXPos)
		{
			_newPos.x -= _speed * Time.deltaTime;
		}

		if(Input.mousePosition.y > _theScreenHeight - _boundary && pos.y < MaxYPos)
		{
			_newPos.y += _speed * Time.deltaTime;
		}

		if(Input.mousePosition.y < 0 + _boundary && pos.y > MinYPos)
		{
			_newPos.y -= _speed * Time.deltaTime;
		}
		transform.position = Vector3.Lerp(transform.position, _newPos,0.1f);
	}
}
