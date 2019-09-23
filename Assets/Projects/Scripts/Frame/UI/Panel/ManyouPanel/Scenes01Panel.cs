using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using System;

public class Scenes01Panel : BasePanel
{
    public Dropdown dropdown;
    public CanvasGroup dropdownGroup;

    public override void InitFind()
    {
        base.InitFind();
        dropdown = FindTool.FindChildComponent<Dropdown>(transform, "Dropdown");
        dropdownGroup = FindTool.FindChildComponent<CanvasGroup>(transform, "Dropdown");
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
                ColorChange(Item01Control.Instance.ItemGroup[0].transform, Color.white);
                break;
            case 1:
                ColorChange(Item01Control.Instance.ItemGroup[0].transform, Color.red);
                break;
            case 2:
                ColorChange(Item01Control.Instance.ItemGroup[0].transform, Color.blue);
                break;
            default:
                break;
        }
    }

    public void Opendropdown()
    {
        Debug.Log("下拉菜单打开");
        dropdownGroup.DOFillAlpha(1.0f, 0.5f, TweenMode.NoUnityTimeLineImpact);
        dropdownGroup.blocksRaycasts = true;
    }

    public void Hidedropdown()
    {
        Debug.Log("下拉菜单关闭");
        dropdownGroup.DOFillAlpha(0, 0.5f, TweenMode.NoUnityTimeLineImpact);
        dropdownGroup.blocksRaycasts = false;
    }

    public override void Open()
    {
        base.Open();

        //Hidedropdown();
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void ColorChange(Transform transform,Color color)
    {
        transform.GetComponent<MeshRenderer>().material.color = color;
    }
}
