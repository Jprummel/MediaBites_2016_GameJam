using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour {
    
    [SerializeField]private Text        _endText;
    [SerializeField]private GameObject _lightObject;
                    private bool _levelHasEnded;
                    public bool levelHasEnded()
                    {
                        return _levelHasEnded;
                    }
	
    public void LevelWin()
    {
        StartCoroutine(LevelEndingWin());
        _levelHasEnded = true;
    }

    public void LevelLose(float value)
    {
        StartCoroutine(LevelEndingLose(value));
        _levelHasEnded = true;
    }

    IEnumerator LevelEndingLose(float waitTime)
    {
        _endText.text = "You lost, better luck next time";
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }

    IEnumerator LevelEndingWin()
    {
        DelegateHandeler.LazerHitEvent(_lightObject);
        _endText.text = "Congratulations get ready for the next level";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
