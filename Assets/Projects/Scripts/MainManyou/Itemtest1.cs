using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Itemtest1 : Item
{
    Scenes01Panel Scenes01Panel;
    // Start is called before the first frame update
    void Start()
    {
        Scenes01Panel = UIManager.GetPanel<Scenes01Panel>(WindowTypeEnum.ForegroundScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EnterTrigger()
    {
        base.EnterTrigger();       
        Scenes01Panel.Opendropdown();
    }

    public override void LeaveTrigger()
    {
        base.LeaveTrigger();
        Scenes01Panel.Hidedropdown();
    }

    //private void OnBecameVisible()
    //{
    //    EnterTrigger();
    //    Debug.Log("进来");
    //}

    //private void OnBecameInvisible()
    //{
    //    Debug.Log("离开");
    //    LeaveTrigger();
    //}
}
