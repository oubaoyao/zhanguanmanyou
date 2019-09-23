using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using System;

public class Scenes01Panel : BasePanel
{
    public Dropdown dropdown;

    public override void InitFind()
    {
        base.InitFind();
        dropdown = FindTool.FindChildComponent<Dropdown>(transform, "Dropdown");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        dropdown.onValueChanged.AddListener(Change);
       
    }

    private void Change(int index)
    {
        switch(index)
        {
            case 0:
                Debug.Log("0");
                break;
            case 1:
                Debug.Log("1");
                break;
            case 2:
                Debug.Log("2");
                break;
            default:
                break;
        }
    }

    public void Opendropdown()
    {
        dropdown.transform.gameObject.GetComponent<CanvasGroup>().DOFillAlpha(1.0f, 0.5f, TweenMode.NoUnityTimeLineImpact);
        dropdown.transform.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void Hidedropdown()
    {
        dropdown.transform.gameObject.GetComponent<CanvasGroup>().DOFillAlpha(0, 0.5f, TweenMode.NoUnityTimeLineImpact);
        dropdown.transform.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public override void Open()
    {
        base.Open();
        Hidedropdown();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
