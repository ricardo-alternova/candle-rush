using DG.Tweening;
using GJam2020.Core;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class StartAnimation : MonoBehaviour
{
    [SerializeField] private Image _inner;
    [SerializeField] private Image _background;
    private AudioSourcePlayer _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _background = GetComponent<Image>();
        _audioSource = SoundManager.Get().FxPlayer;
        Assert.IsNotNull(_background);
        Assert.IsNotNull(_audioSource);
    }

    public void Show()
    {
        _background.color = Color.white;
    }

    public void Fill()
    {
        _audioSource.Play();
        _inner.DOFillAmount(1, 0.9f);
        _background.transform.DOPunchScale(
            punch: Vector3.one * 1.1f, 
            duration: 0.8f, 
            vibrato: 10, 
            elasticity: 0.5f);
    }
}
