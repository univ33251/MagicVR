using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using System;
using UnityEngine.InputSystem.Utilities;

public class PlayerControllerManager : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty input;

    private Animator animator;
    private MP mp;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mp = GetComponent<MP>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnEnable()
    {
        var action = input.action;
        action.performed += OnPerformed;
        action.Enable();
    }

    private void OnDisable()
    {
        var action = input.action;
        action.performed -= OnPerformed;
        action.Disable();
    }


    void OnPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("performed");
        if (mp.GetMP() >= 1)
        {
            mp.RemoveMP(1);
            animator.SetTrigger("Attack");
        }
    }



}
