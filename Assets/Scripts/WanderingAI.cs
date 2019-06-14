using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 1.5f; //значение скорости
    public float obstacleRange = 0.5f; // рейнж проверки



    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); // движемся вперед каждій кадр

        Ray ray = new Ray(transform.position, transform.forward); // создаем луч из центра обьекта в направлении обєкта
        RaycastHit hit; 

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange) {

                float angle = Random.Range(-110, 100);
                transform.Rotate(0, angle, 0);

            }
        }
    }
}
