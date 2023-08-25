using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class RatHead : MonoBehaviour
{
    [SerializeField]private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }
    
    private void Empty(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(0,1,_lerpDuration,Fill));
    }
    
    public void ToLost()
    {
        StartCoroutine(Filling(1, 0, _lerpDuration, Empty));
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> fillingEnd)
    {
        float nextValue;
        float elapsed = 0;
         
        while (elapsed < duration)
	    {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
	    }
            fillingEnd?.Invoke(endValue);
    }
}
