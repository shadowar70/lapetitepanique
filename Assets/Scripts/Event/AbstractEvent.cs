using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEvent : ScriptableObject
{
	public abstract void Execute(EventManager manager);
	public abstract string Label { get; }
}
