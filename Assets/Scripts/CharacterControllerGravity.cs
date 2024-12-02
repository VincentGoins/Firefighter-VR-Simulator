using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGravity : MonoBehaviour
{
    private bool _climbing;
    private CharacterController _controller;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        NewClimbProvider.ClimbActive += ClimbActive;
        NewClimbProvider.ClimbInactive += ClimbInactive;
    }

    private void OnDestroy()
    {
        NewClimbProvider.ClimbActive -= ClimbActive;
        NewClimbProvider.ClimbInactive -= ClimbInactive;
    }
    
    void FixedUpdate()
    {
        if(_controller.isGrounded == false && _climbing == false)
        {
            _controller.SimpleMove(new Vector3());
        }
    }

    private void ClimbActive()
    {
        _climbing = true;
    }
    private void ClimbInactive()
    {
        _climbing = false;
    }
}