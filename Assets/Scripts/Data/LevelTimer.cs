using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour {
    [SerializeField]private int         _startTimer;
    [SerializeField]private float       _timer;
    [SerializeField]private Text        _timerText;
    [SerializeField]private Text        _levelCounter;
                    private LevelEnd    _levelEnd;

	// Use this for initialization
	void Start () {
        _levelEnd = GetComponent<LevelEnd>();
        _timer    = _startTimer;
        _levelCounter.text = "Level : " + SceneManager.GetActiveScene().buildIndex.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_levelEnd.levelHasEnded())
        {
            _timerText.text = "Time left : " + _timer.ToString("0");
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            if (_timer <= 0)
            {
                _levelEnd.LevelLose(2);
            }
        }
	}
}
