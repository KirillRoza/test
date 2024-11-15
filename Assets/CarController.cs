using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float acceleration = 50f;
    public float maxSpeed = 100f;
    public float turnSpeed = 5f;
    public float downForce = 10f; // ��������� ����

    private Rigidbody rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1500f; // ��������� �����
        rb.centerOfMass = new Vector3(0, -0.5f, 0); // ����� ���� ��� ������������
    }

    void FixedUpdate()
    {
        HandleAcceleration();
        HandleSteering();
        ApplyDownForce();
    }

    void HandleAcceleration()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
            rb.AddForce(transform.forward * currentSpeed, ForceMode.Force); // ���������� ���� ��� ��������
        }
        else
        {
            currentSpeed *= 0.98f; // ������� ������ ��������
        }
    }

    void HandleSteering()
    {
        float turn = Input.GetAxis("Horizontal");
        if (currentSpeed > 0.1f)
        {
            transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime);
        }
    }
    void ApplyDownForce()
    {
        rb.AddForce(-transform.up * downForce * rb.velocity.magnitude);
    }
}
