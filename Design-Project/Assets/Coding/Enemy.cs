using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    int desiredIndex = 0;
    public float speed = 2f;
    void Start()
    {

    }


    void Update()
    {
        if ((transform.position - positions[0].position).magnitude < 0.4f)
        {
            desiredIndex = 1;
        }
        if ((transform.position - positions[1].position).magnitude < 0.4f)
        {
            desiredIndex = 2;
        }
        if ((transform.position - positions[2].position).magnitude < 0.4f)
        {
            desiredIndex = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, positions[desiredIndex].position, speed * Time.deltaTime);

        Vector3 targetDirection = positions[desiredIndex].position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
