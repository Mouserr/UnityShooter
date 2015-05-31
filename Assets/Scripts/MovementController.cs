using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

    private const float sideSpeed = 0.2f;
    private const float forwardSpeed = 0.2f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 delta = transform.localRotation * new Vector3(-sideSpeed, 0, 0);
            transform.localPosition += new Vector3(delta.x, 0, delta.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 delta = transform.localRotation * new Vector3(0, 0, forwardSpeed);
            transform.localPosition += new Vector3(delta.x, 0, delta.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 delta = transform.localRotation * new Vector3(sideSpeed, 0, 0);
            transform.localPosition += new Vector3(delta.x, 0, delta.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 delta = transform.localRotation * new Vector3(0, 0, -forwardSpeed);
            transform.localPosition += new Vector3(delta.x, 0, delta.z);
        }
    }

}
