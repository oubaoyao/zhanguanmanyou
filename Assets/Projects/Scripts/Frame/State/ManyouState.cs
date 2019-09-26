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
                MTFrame.MTEvent.EventType.CollideEventName.ToString(),
                MTFrame.MTEvent.EventType.RayEventName.ToString(),
            };
        }
        set { }
    }

    public override void OnListenerMessage(EventParamete parameteData)
    {
        string eventname = parameteData.EvendName;
        
        if (eventname == MTFrame.MTEvent.EventType.CollideEventName.ToString())
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
        else if(eventname == MTFrame.MTEvent.EventType.RayEventName.ToString())
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
        CurrentTask.ChangeTask(new Scenes01Task(this));
        CurrentTask.ChangeTask(new ManyouLoadingTask(this));
    }

    public static void SentCollideEvent(CollideEventName st)
    {
        EventParamete eventParamete = new EventParamete();
        eventParamete.AddParameter(st);
        EventManager.TriggerEvent(GenericEventEnumType.Message, MTFrame.MTEvent.EventType.CollideEventName.ToString(), eventParamete);
    }

    public static void SentRayEvent(RayEventName st)
    {
        EventParamete eventParamete = new EventParamete();
        eventParamete.AddParameter(st);
        EventManager.TriggerEvent(GenericEventEnumType.Message, MTFrame.MTEvent.EventType.RayEventName.ToString(), eventParamete);
    }
}
