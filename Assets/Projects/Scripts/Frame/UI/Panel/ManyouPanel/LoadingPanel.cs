using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using System;

public class LoadingPanel : BasePanel
{
    public Slider Loadingslider;
    public Text text;

    public override void InitFind()
    {
        base.InitFind();
        Loadingslider = FindTool.FindChildComponent<Slider>(transform, "Slider");
        text = FindTool.FindChildComponent<Text>(transform, "Text");
    }

    public override void Open()
    {
        base.Open();
        Main.Instance.MainCamera.transform.gameObject.SetActive(true);
        LoadingStart();
        EventManager.RemoveUpdateListener(MTFrame.MTEvent.UpdateEventEnumType.Update, "OnUpdate", OnUpdate);
        EventManager.AddUpdateListener(MTFrame.MTEvent.UpdateEventEnumType.Update, "OnUpdate", OnUpdate);
    }

    private void OnUpdate(float timeProcess)
    {
        text.text = (Loadingslider.value * 100).ToString() + "%";
    }

    public override void Hide()
    {
        base.Hide();
        EventManager.RemoveUpdateListener(MTFrame.MTEvent.UpdateEventEnumType.Update, "OnUpdate", OnUpdate);
        Main.Instance.MainCamera.transform.gameObject.SetActive(false);
    }

    public void LoadingStart()
    {
        Loadingslider.value = 0;
        text.text = "";
        DG.Tweening.DOTween.To(() => Loadingslider.value, x => Loadingslider.value = x, 0.99f, 12);
    }

    public void LoadingComplete()
    {
        text.text = "100%";
        Loadingslider.value = 1;
    }
}
