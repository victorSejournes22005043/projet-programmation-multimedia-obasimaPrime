using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _moveSpeed = 10f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _characterController.Move(move * (Time.deltaTime * _moveSpeed));
    }
}



