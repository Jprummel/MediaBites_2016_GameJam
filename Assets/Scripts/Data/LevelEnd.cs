using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour {
    
    [SerializeField]private Text        _endText;
                    private Animator    _animator;
    [SerializeField]private GameObject _lightObject;
                    private bool _levelHasEnded;
                    public bool levelHasEnded()
                    {
                        return _levelHasEnded;
                    }
    
	// Use this for initialization
	void Start () {
        _animator   = GameObject.Find("Main Camera").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LevelWin()
    {
        StartCoroutine(LevelEndingWin());
        _levelHasEnded = true;
    }

    public void LevelLose()
    {
        StartCoroutine(LevelEndingLose());
        _levelHasEnded = true;
    }

    IEnumerator LevelEndingLose()
    {
        _endText.text = "You suck... Git gud and try again";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    IEnumerator LevelEndingWin()
    {
        //_animator.Play("Camera_Win_Animations");
        //yield return new WaitForSeconds(2);
        DelegateHandeler.LazerHitEvent(_lightObject);
        _endText.text = "Congratulations get ready for the next level";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
