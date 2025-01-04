using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator PlayerAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        float speed = Mathf.Sqrt(verticalInput * verticalInput + horizontalInput * horizontalInput);

        PlayerAnimator.SetFloat("Walk", speed);
    }
}
