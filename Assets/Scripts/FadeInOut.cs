using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {

    private Animator _animator;
    [SerializeField]private float _fadeTime;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}

    public void FadeIn()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(FadeInTimer());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutTimer());
    }

    IEnumerator FadeOutTimer()
    {
        _animator.Play("FadeOut");
        yield return new WaitForSeconds(_fadeTime);
        this.gameObject.SetActive(false);
        
    }

    IEnumerator FadeInTimer()
    {
        _animator.Play("FadeIn");
        yield return new WaitForSeconds(_fadeTime);
        
    }

}
