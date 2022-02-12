using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState : ScriptableObject
{
    [HideInInspector] public CameraMove camera {get; set;}
    [HideInInspector] public Vector2 velocity = new Vector2(0, 0);

    public virtual void Init() { }

    public abstract void Run();

    public abstract void ChangeSize(float size);
}
