using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterController characterController;
    [SerializeField] private float speed;
    
    private static readonly int Run = Animator.StringToHash("Run");

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if (Vector3.SqrMagnitude(movement) > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            animator.SetBool(Run, true);
            characterController.SimpleMove(movement * speed);
        }
        else
        {
            animator.SetBool(Run, false);
        }
    }
}
