using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AbstractGenerator : MonoBehaviour
{
	public abstract GameObject GenerateCharacter(GameObject model);
}
