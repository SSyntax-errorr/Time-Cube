using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;

    public Text tooltipText;

    void Awake()
    {
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    void Start()
    {
        gameObject.SetActive(false);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ShowTooltip(string tip){
        gameObject.SetActive(true);
        tooltipText.text = tip;
    }

    public void HideTooltip(){
        gameObject.SetActive(false);
        tooltipText.text = string.Empty;
    }
}
