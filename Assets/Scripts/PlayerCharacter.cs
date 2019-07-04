using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health = 0;

    // Start is called before the first frame update
    void Start()
    {
        _health = 5;
    }

    // Update is called once per frame
    public void Heart(int damage)
    {
        _health -= damage;
        Debug.Log("Current heealth: " + _health);
    }
}
