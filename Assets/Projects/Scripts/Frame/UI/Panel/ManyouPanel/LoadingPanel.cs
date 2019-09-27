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
    public static string SceneName = "Scene01";

    protected override void Awake()
    {
        base.Awake();
        transform.SetAsLastSibling();
    }

    public override void InitFind()
    {
        base.InitFind();
        Loadingslider = FindTool.FindChildComponent<Slider>(transform, "Slider");
        text = FindTool.FindChildComponent<Text>(transform, "Text");
    }

    public override void Open()
    {
        base.Open();
        Reset();
        SceneManager.LoadSceneAsync(SceneName, MTFrame.MTScene.LoadingModeType.UnityLocal, 
            () => { LoadingStart(); }, null, () => { if (Loadingslider.value > 0.33f) { LoadingComplete(); } else { Invoke("LoadingComplete", 1.0f); }  });
    }

    public override void Hide()
    {
        base.Hide();     
        Main.Instance.MainCamera.transform.gameObject.SetActive(false);
        UIManager.ChangePanelState<Scenes01Panel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Open);

    }

    public void LoadingStart()
    {
        Loadingslider.value = 0;
        text.text = "";
        StartCoroutine("LoadingSlide");  
    }

    public void LoadingComplete()
    {
        StopCoroutine("LoadingSlide");
        text.text = "100%";
        Loadingslider.value = 1;
        TimeTool.Instance.AddDelayed(TimeDownType.NoUnityTimeLineImpact, 2.0f, Hide);
        Debug.Log("读条完成！");
    }

    IEnumerator LoadingSlide()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            Loadingslider.value += 0.01f;
            text.text = ((int)(Loadingslider.value * 100)).ToString() + "%";
            if (Loadingslider.value == 0.99f)
            {
                yield break;
            }
        }
    }

    private void Reset()
    {
        Main.Instance.MainCamera.transform.gameObject.SetActive(true);
        text.text = "";
        Loadingslider.value = 0;
    }
}
