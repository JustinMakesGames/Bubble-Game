using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float speed;
    private float _horizontalMovement;
    private float _verticalMovement;


    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(_horizontalMovement, 0, _verticalMovement);
        _rb.velocity = direction * speed * Time.deltaTime;
    }

}
