using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    [SerializeField] public Material mat;


    private float blendValue;
    private float blendMax = 1.0f;
    private float blendMin = 0.0f;



// Start is called before the first frame update
   void Start()
   {
   }

    // Update is called once per frame9/
    void Update()
    {
        
        if (Input.GetKey("space") && blendValue < blendMax)
        {
            blendValue  = blendValue + 1 * Time.deltaTime;
            mat.SetFloat("_Blend",blendValue);
        }
        else if (Input.GetKeyUp("space")==false && blendValue > blendMin)
        {
            blendValue = blendValue - 1 * Time.deltaTime;
            mat.SetFloat("_Blend",blendValue);
        }
    }
}
