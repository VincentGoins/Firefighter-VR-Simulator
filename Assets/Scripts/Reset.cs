using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

public class Reset : MonoBehaviour
{

        public InputActionProperty reset;
        
        public Transform resetSpot;

        public Transform targets;
        public float height;
        public bool rotate;

        public float x;
        public float y;
        public float z;
    // Start is called before the first frame update
    

    public void ResetPlace()
    {
        targets.position = resetSpot.position;
        targets.position = new Vector3(targets.position.x, height, targets.position.z);
        if(rotate)
        {
            targets.eulerAngles = new Vector3(x,y,z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    if(reset.action.WasPressedThisFrame())
        {
            ResetPlace();
        }
    }
}
