using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    private Animator _animator;
	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LevelWin()
    {
        StartCoroutine(LevelEnding());
    }

    IEnumerator LevelEnding()
    {
        _animator.Play("Camera_Win_Animation");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings + 1);
    }
}
