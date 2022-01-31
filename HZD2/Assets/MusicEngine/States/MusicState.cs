using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MusicState : ScriptableObject
{
    [SerializeField] private AudioClip[] clips;

    public virtual void Init() {}

    public abstract void Run();

    public virtual void Dest() {}
}
