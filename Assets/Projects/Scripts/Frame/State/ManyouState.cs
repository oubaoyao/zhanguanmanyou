using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using MTFrame.MTEvent;

public class ManyouState : BaseState
{
    public override string[] ListenerMessageID
    {
        get
        {
            return new string[]
            {
                //事件名string类型
                EventType.CollideEventName.ToString(),
                EventType.RayEventName.ToString(),
            };
        }
        set { }
    }

    public override void OnListenerMessage(EventParamete parameteData)
    {
        string eventname = parameteData.EvendName;
        
        if (eventname == EventType.CollideEventName.ToString())
        {
            CollideEventName data = parameteData.GetParameter<CollideEventName>()[0];
            switch (data)
            {
                case CollideEventName.ccc:
                    Debug.Log("ccc");
                    break;
                case CollideEventName.ddd:
                    Debug.Log("ddd");
                    break;
                default:
                    break;
            }
        }
        else if(eventname == EventType.RayEventName.ToString())
        {
            RayEventName data = parameteData.GetParameter<RayEventName>()[0];
            switch(data)
            {
                case RayEventName.aaa:
                    Debug.Log("aaa");
                    break;
                case RayEventName.bbb:
                    Debug.Log("bbb");
                    break;
                default:
                    break;
            }
        }
    }

    public override void Enter()
    {
        base.Enter();
        CurrentTask.ChangeTask(new ManyouLoadingTask(this));
        //SceneManager.LoadSceneAsync("Scene01", MTFrame.MTScene.LoadingModeType.UnityLocal,()=> { UIManager.GetPanel<LoadingPanel>(WindowTypeEnum.Screen).LoadingStart(); },null,()=> { UIManager.GetPanel<LoadingPanel>(WindowTypeEnum.Screen).LoadingComplete(); });
    }

    public static void SentCollideEvent(CollideEventName st)
    {
        EventParamete eventParamete = new EventParamete();
        eventParamete.AddParameter(st);
        EventManager.TriggerEvent(GenericEventEnumType.Message, EventType.CollideEventName.ToString(), eventParamete);
    }

    public static void SentRayEvent(RayEventName st)
    {
        EventParamete eventParamete = new EventParamete();
        eventParamete.AddParameter(st);
        EventManager.TriggerEvent(GenericEventEnumType.Message, EventType.RayEventName.ToString(), eventParamete);
    }
}
