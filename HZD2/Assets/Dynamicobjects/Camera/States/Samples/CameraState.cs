using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState : ScriptableObject
{
    [HideInInspector] public CameraMove camera {get; set;}
    public float velocity = 0;

    public virtual void Init() { }

    public abstract void Run();
}
