using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.HandPosing;
using UnityEngine;

public class ObjectGrabbed : MonoBehaviour
{
    public OVRGrabbable grabbable;
    
    public ObjCollisionDetection collisionDetection1;
    public ObjCollisionDetection collisionDetection2;

    public Animator anim;

    private void Update()
    {
        if (grabbable.isGrabbed)
        {
            OnGrab();
        }
        else if (!grabbable.isGrabbed)
        {
            OnRelese();
        }
    }

    void OnGrab()
    {
        anim.SetBool("Start", true);
    }

    void OnRelese()
    {
        if (!collisionDetection1.isColliding && !collisionDetection2.isColliding)
        {
            anim.SetBool("Start", false);
            anim.SetFloat("Speed", -1);
        }
    }
}
