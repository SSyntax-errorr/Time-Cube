using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
  public string tip;

  void OnMouseEnter()
  {
    Debug.Log("x");
    TooltipManager._instance.ShowTooltip(tip);
  }

  void OnMouseUp()
  {
    Debug.Log("x");
  }

  void OnMouseOver()
  {
    Debug.Log("x");
    TooltipManager._instance.ShowTooltip(tip);
  }

  void OnMouseExit()
  {
    TooltipManager._instance.HideTooltip();
  }
}
