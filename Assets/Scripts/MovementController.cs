using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

    private const float sideSpeed = 0.1f;
    private const float forwardSpeed = 0.3f;

    private Vector3 prevMousePosition = new Vector3(0,0,0);
    private void OnEnable()
    {
        prevMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += new Vector3(-sideSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += new Vector3(0, 0, forwardSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(sideSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += new Vector3(0, 0, -forwardSpeed);
        }

        // to velocity
        Vector3 delta = Input.mousePosition - prevMousePosition;
        transform.Rotate(Vector3.up, delta.x * Mathf.PI / Screen.width);
        transform.Rotate(Vector3.right, -delta.y * Mathf.PI / Screen.height);
        prevMousePosition = Input.mousePosition;

    }

}
