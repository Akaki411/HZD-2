using System.Collections;
using UnityEngine;

public class Equalizer : MonoBehaviour
{
    [SerializeField] private float _length = 1;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _reloadInterval = 0.1f;
    [SerializeField] private RectTransform[] planes;
    private float[] _channels = new float[64];
    private void Start()
    {
        StartCoroutine(ReloadSamples());
    }

    private void FixedUpdate()
    {
        for (int i = 0, j = 0; i < 64; i += 4, j++)
        {
            planes[j].localScale = new Vector2(1,  Mathf.Clamp01(Mathf.Lerp(planes[j].localScale.y, _channels[i] * _length, _speed)));
        }
    }

    private IEnumerator ReloadSamples()
    {
        AudioListener.GetSpectrumData(_channels, 0, FFTWindow.Blackman);
        yield return new WaitForSeconds(_reloadInterval);
        StartCoroutine(ReloadSamples());
    }
}
