using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEvent : ScriptableObject
{
	public AudioClip audio = null;

	public abstract void Execute(EventManager manager);
	public abstract string Label { get; }
}
