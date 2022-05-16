using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<ObjectGrabbed> pedistals = new List<ObjectGrabbed>();

    public void SetAsInControl(int index)
    {
        if (index == 0)
        {
            pedistals[index].isInControl = true;
            pedistals[1].isInControl = false;
            pedistals[2].isInControl = false;
            pedistals[3].isInControl = false;
        }
        else if (index == 1)
        {
            pedistals[index].isInControl = true;
            pedistals[2].isInControl = false;
            pedistals[3].isInControl = false;
            pedistals[0].isInControl = false;
        }
        else if (index == 2)
        {
            pedistals[index].isInControl = true;
            pedistals[0].isInControl = false;
            pedistals[1].isInControl = false;
            pedistals[3].isInControl = false;  
        }
        else if (index == 3)
        {
            pedistals[index].isInControl = true;
            pedistals[1].isInControl = false;
            pedistals[2].isInControl = false;
            pedistals[0].isInControl = false;
        }
    }
}
