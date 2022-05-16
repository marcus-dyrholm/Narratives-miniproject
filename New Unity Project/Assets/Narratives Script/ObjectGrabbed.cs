using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.HandPosing;
using UnityEngine;
using UnityEngine.Video;

public class ObjectGrabbed : MonoBehaviour
{
    public OVRGrabbable grabbable;
    
    public ObjCollisionDetection RightCollider;
    public ObjCollisionDetection LeftCollider;

    public VideoClip RightSideVideo;
    public VideoClip LeftSideVideo;

    private bool lerpToVideo;

    public Material skybox;

    public Animator anim;

    public VideoPlayer videoPlayer;

    private float blendValue;
    private float blendMin = 0;
    private float blendMax = 1.0f;

    private void Start()
    {
        skybox = RenderSettings.skybox;
    }

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

        if (RightCollider.isColliding)
        {
            ChangeVideo(RightSideVideo);
            Debug.Log("is colliding");
        }
        else if(LeftCollider.isColliding)
        {
             ChangeVideo(LeftSideVideo);
        }

        if (!LeftCollider.isColliding && !RightCollider.isColliding)
        {
            lerpToVideo = false;
        }

        if (lerpToVideo)
        {
            if (blendValue < blendMax)
            {
                blendValue  = blendValue + 1 * Time.deltaTime;
            }
            skybox.SetFloat("_Blend", blendValue);
        }
        else
        {
            if (blendValue > blendMin)
            {
                blendValue = blendValue - 1 * Time.deltaTime;
            }
            skybox.SetFloat("_Blend", blendValue);
        }
        Debug.Log(lerpToVideo);
    }

    void OnGrab()
    {
        anim.SetBool("Start", true);
    }

    void OnRelese()
    {
        if (!RightCollider.isColliding && !LeftCollider.isColliding)
        {
            anim.SetBool("Start", false);
        }
    }

    void ChangeVideo(VideoClip video)
    {
        videoPlayer.clip = video;
        lerpToVideo = true;
    }
}
