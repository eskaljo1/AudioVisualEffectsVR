using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float sensitivityX = 8F;
    public float sensitivityY = 8F;
    public float minimumY = -90.0f;
    public float maximumY = 90.0f;
    float rotationY = 0.0f;
    float rotationX = 180.0f;

    float mainSpeed = 3.0f;
    private float totalRun = 1.0f;

    void Update()
    {

        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        Vector3 p = GetBaseInput();
        totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
        p = p * mainSpeed;

        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        transform.Translate(p);

        newPosition.x = transform.position.x;
        newPosition.z = transform.position.z;
        transform.position = newPosition;

    }

    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
