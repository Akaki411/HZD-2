using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraState", menuName = "Camera/MusicShakeState")]
public class CameraStateMusicShake : CameraState
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float size = 5f;
    [SerializeField] private float sizeSpeed = 1f;
    [SerializeField] private float kick = 0.5f;

    [SerializeField] private Vector3 offset;

    private bool _sizing;
    [SerializeField] private float[] spectrum = new float[64];

    public override void Init()
    {

    }

    public override void Run()
    {
        if (size != camera.mainCamera.orthographicSize)
        {
            camera.mainCamera.orthographicSize = Mathf.SmoothStep(camera.mainCamera.orthographicSize, size, sizeSpeed);
        }

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);

        if(spectrum[0] > kick)
        {
            Kick(spectrum[0]);
        }

        camera.transform.position = Vector3.Lerp(camera.transform.position, camera.purpose.transform.position + offset, speed);
    }

    public override void ChangeSize(float size)
    {
        this.size = size;
    }

    private void Kick(float kick)
    {
        camera.mainCamera.orthographicSize = size - kick;
    }
}
