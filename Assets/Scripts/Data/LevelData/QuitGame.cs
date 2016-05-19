using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
    [SerializeField]private float _exitTime;

    public void Quit()
    {
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(_exitTime);
        Application.Quit();
    }
}
