using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

    private const float sideSpeed = 0.1f;
    private const float forwardSpeed = 0.3f;
    private Vector3 prevPos;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    private float startY;

    private void Awake()
    {
        startY = transform.localPosition.y;
    }

    private void OnEnable()
    {
        prevPos = Input.mousePosition;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += transform.localRotation * new Vector3(-sideSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.localRotation * new Vector3(0, 0, forwardSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.localRotation * new Vector3(sideSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += transform.localRotation * new Vector3(0, 0, -forwardSpeed);
        }
        transform.localPosition = new Vector3(transform.localPosition.x, startY, transform.localPosition.z);

        // to velocity
        //Vector3 positionFromCenter = Input.mousePosition - new Vector3(Screen.width/2f, Screen.height/2f);
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = -verticalSpeed * Input.GetAxis("Mouse Y");
      /*  if (transform.localRotation.eulerAngles.x > Mathf.Deg2Rad*17 && v > 0 
            && transform.localRotation.eulerAngles.x < Mathf.Deg2Rad*360
            || transform.localRotation.eulerAngles.x < Mathf.Deg2Rad*(230) && v < 0)
        {
            v = 0;
        }*/
        transform.Rotate(v, h, 0);
        var eulerAngles = transform.localRotation.eulerAngles;
        if (eulerAngles.x > 45 && eulerAngles.x < 320)
        {
            if (v < 0) eulerAngles.x = 320;
            else eulerAngles.x = 45;
        }
        eulerAngles.z = 0;
        transform.localRotation = Quaternion.Euler(eulerAngles);
    }

}
