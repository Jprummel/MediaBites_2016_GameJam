using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {
    [SerializeField]private int         _startTimer;
    [SerializeField]private float       _timer;
    [SerializeField]private Text        _timerText;
                    private LevelEnd    _levelEnd;

	// Use this for initialization
	void Start () {
        _levelEnd = GetComponent<LevelEnd>();
        _timer    = _startTimer;
	}
	
	// Update is called once per frame
	void Update () {
        if (!_levelEnd.levelHasEnded())
        {
            _timerText.text = _timer.ToString("0");
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            if (_timer <= 0)
            {
                _levelEnd.LevelLose();
            }
        }
	}
}
