using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCollisionDetection : MonoBehaviour
{
    private Renderer _renderer;
    private Color _savedColor;
    public bool isColliding;

    public ObjectGrabbed objectGrabbed;

    private void Start()
    {
        _renderer = this.GetComponent<Renderer>();
        _savedColor = _renderer.material.GetColor("_TintColor");
        objectGrabbed = transform.parent.GetComponent<ObjectGrabbed>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            _renderer.material.SetColor("_TintColor", Color.magenta);
            Debug.Log("aslmdadm");
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Object")
        {
            _renderer.material.SetColor("_TintColor", _savedColor);
            isColliding = false;

            objectGrabbed.lerpToVideo = false;
        }

    }
}
