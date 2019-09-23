using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCheck : MonoBehaviour
{
    private RaycastHit hitInfo;
    private Transform tr;
    public float maxDistance = 50.0f;

    public Camera Maincamera;
    // Use this for initialization
    void Start()
    {
        hitInfo = new RaycastHit();
    }

    void Awake()
    {
        tr = Maincamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(tr.position, tr.forward, out hitInfo, maxDistance))
        {
            string tag = hitInfo.transform.gameObject.tag;
            //if(hitInfo.transform.gameObject.GetComponent<Itemtest1>())
            //{
            //    hitInfo.transform.gameObject.GetComponent<Itemtest1>().EnterTrigger();
            //}
            //else if(tag == "aaa" ||tag == "bbb")
            if (tag == "aaa" || tag == "bbb")
            {
                ManyouState.SentRayEvent((RayEventName)Enum.Parse(typeof(RayEventName), tag));
            }
            
        }
        Debug.DrawRay(tr.position, tr.forward* maxDistance, Color.red);

        //GetHitInfo();
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "ccc" || tag == "ddd")
        {
            ManyouState.SentCollideEvent((CollideEventName)Enum.Parse(typeof(CollideEventName), tag));
        }
    }

}
