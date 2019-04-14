using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/ FPS input")]

public class FPSInput : MonoBehaviour
{
    public float speed = 0.1f;
    private CharacterController _charController;
    public float gravity = -9.8f;


    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        //for limit movement on gipotenuza
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        // correct on fps behavior
        movement *= Time.deltaTime;
        //transfor move vector in global coordinate
        movement = transform.TransformDirection(movement);

        _charController.Move(movement);
   
    }
}
