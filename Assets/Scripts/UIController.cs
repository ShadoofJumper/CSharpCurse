using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text scoreLabel;

    void Update()
    {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        Debug.Log("open settings");
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
