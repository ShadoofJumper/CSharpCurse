using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{

    public float ballSpeed = 3.0f;
    public float rangeMax = 16.0f;
    public float rangeMin = -16.0f;

    private int _ballDirection = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, _ballDirection * ballSpeed * Time.deltaTime);

        bool bounce = false;

        if (transform.position.z < rangeMin || transform.position.z > rangeMax)
        {
            _ballDirection = -_ballDirection;
            bounce = true;
        }

        if (bounce)
        {
            transform.Translate(0, 0, _ballDirection * ballSpeed * Time.deltaTime);
        }
    }
}
