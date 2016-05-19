using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {
    [SerializeField]private int     _startTimer;
    [SerializeField]private int     _timer;
    [SerializeField]private Text _timerText;
    private bool _timeUp;
    public bool timeUp()
    {
        return _timeUp;
    }

	// Use this for initialization
	void Start () {
        _timer = _startTimer;
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(ReduceTimer());
        if (_timer <= 0)
        {
            _timeUp = true;
        }
	}

    IEnumerator ReduceTimer()
    {
        yield return new WaitForSeconds(1);
        _timer--;
    }
}
