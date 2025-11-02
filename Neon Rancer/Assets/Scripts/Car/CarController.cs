using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   
    [Header("Wheels Trasform")]
    public Transform frontLeftWheels;
    public Transform frontRightWheels;
    public Transform rareLeftWheels;
    public Transform rareRightWheels;

    [Header("Wheels Colliders")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    [Header("Car Setting")]
    public float maxtorque;
    public float maxsteeringAngle;
    public float brakeTorque;

    public Transform carCenterofMass;
    public Rigidbody rb;
    public bool isCarStarted = false;
    public bool isbraking = false;

    float horizontalInput, verticalInput;
    float torque,steeringAngle;

   

    void Start()
    {
        rb.centerOfMass = carCenterofMass.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        WheelsUpdate();
        Movement();
    }
    void Movement()
    {
        if (isCarStarted)
        {
            horizontalInput = SimpleInput.GetAxis("Horizontal");
            verticalInput = SimpleInput.GetAxis("Vertical");

            //Torque
            torque = maxtorque * verticalInput;
            frontLeftWheelCollider.motorTorque = torque;
            frontRightWheelCollider.motorTorque = torque;
            rearLeftWheelCollider.motorTorque = torque;
            rearRightWheelCollider.motorTorque = torque;

            // Steering
            steeringAngle = maxsteeringAngle * horizontalInput;
            frontLeftWheelCollider.steerAngle = steeringAngle;
            frontRightWheelCollider.steerAngle = steeringAngle;

            //HandBrake
            if (isbraking || Input.GetKey(KeyCode.Space))
            {
                rearLeftWheelCollider.brakeTorque = brakeTorque;
                rearRightWheelCollider.brakeTorque = brakeTorque;
                frontLeftWheelCollider.brakeTorque = brakeTorque;
                frontRightWheelCollider.brakeTorque = brakeTorque;
            }
            else
            {
                rearLeftWheelCollider.brakeTorque = 0;
                rearRightWheelCollider.brakeTorque = 0;
                frontLeftWheelCollider.brakeTorque = 0;
                frontRightWheelCollider.brakeTorque = 0;
            }
        }

    }
   
    private void WheelsUpdate()
    {
        WheelsPos(frontRightWheelCollider, frontRightWheels);
        WheelsPos(frontLeftWheelCollider, frontLeftWheels);
        WheelsPos(rearLeftWheelCollider, rareLeftWheels);
        WheelsPos(rearRightWheelCollider, rareRightWheels);
    }
    void WheelsPos(WheelCollider _wheelCollider,Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        _wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    
}
