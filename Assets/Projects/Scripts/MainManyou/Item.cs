using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public bool IsTrigger = false;
    public virtual void EnterTrigger()
    {

    }

    public virtual void LeaveTrigger()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsTrigger)
        {
            if (other)
                EnterTrigger();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(IsTrigger)
        {
            LeaveTrigger();
        }
        
    }

}
