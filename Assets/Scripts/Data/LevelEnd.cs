using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour {
    
    [SerializeField]private Text        _endText;
                    private Animator    _animator;
    
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
    }

    public void LevelLose()
    {
        StartCoroutine(LevelEndingLose());
    }

    IEnumerator LevelEndingLose()
    {
        _endText.text = "You suck... Git gud and try again";
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene(0);
    }

    IEnumerator LevelEndingWin()
    {
        _animator.Play("Camera_Win_Animations");
        yield return new WaitForSeconds(2);
        _endText.text = "Congratulations get ready for the next level";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings + 1);
    }
}
