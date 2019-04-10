using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2,
    }
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivyriHor = 7.0f;
    public float sensitivyriVer = 7.0f;

    public float minimumVect = -45.0f;
    public float maximumVect = 45.0f;

    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null){
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X")* sensitivyriHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivyriVer;

            _rotationX = Mathf.Clamp(_rotationX, minimumVect, maximumVect);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivyriVer;
            _rotationX = Mathf.Clamp(_rotationX, minimumVect, maximumVect);

            float delta = Input.GetAxis("Mouse X") * sensitivyriHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                
        }
    }
}
