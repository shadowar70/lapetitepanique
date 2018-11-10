using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGenerator : AbstractGenerator
{
  public override GameObject GenerateCharacter(GameObject model)
  {
    var generated = GameObject.Instantiate(model, transform.position, model.transform.rotation);
    return generated;
  }
}
