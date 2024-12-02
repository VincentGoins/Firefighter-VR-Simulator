using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

public class RecenteOrigin : MonoBehaviour
{

    public InputActionProperty recenterBttn;

    
    public Transform target;
    // Start is called before the first frame update
    

    public void Recenter()
    {
        XROrigin xrOrigin = GetComponent<XROrigin>();
      
        xrOrigin.MoveCameraToWorldLocation(target.position);
        xrOrigin.MatchOriginUpCameraForward(target.up, target.forward);
        
    }


    // Update is called once per frame
    void Update()
    {
        if(recenterBttn.action.WasPressedThisFrame())
        {
            Recenter();
        }
    }
}
