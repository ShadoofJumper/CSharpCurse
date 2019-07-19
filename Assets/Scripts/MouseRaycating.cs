using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseRaycating : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        //Hide cursor
       // Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&  !(EventSystem.current.IsPointerOverGameObject()))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // get component transform from object dat we hit
                GameObject hitObject = hit.transform.gameObject;
                // try get component ReactiveTarget, 
                // if this script is attach to object, then object is active
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }

        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void OnGUI()
    {
        //Debug.Log("OnGui ");
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
