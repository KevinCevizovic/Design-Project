using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    List<Vector3> desiredPostions = new List<Vector3>();

    public GameObject arrow;
    public GameObject arrowPlane;
    public Transform arrowStart;
    public Transform arrowEnd;

    public void Update()
    {
        arrow.transform.Rotate(new Vector3(0f, -0.6f, 0f));
        if(desiredPostions.Count >= 4)
        {
            Play();
        }
    }

    public void test()
    {
        Instantiate(arrowPlane, arrow.transform.position, arrow.transform.rotation);
        arrow.transform.position = arrowEnd.transform.position;

        // Add positions to list
        desiredPostions.Add(arrowStart.transform.position);

        foreach (var item in desiredPostions)
        {
            Debug.Log(item);
        }
    }

    public void Play()
    {

    }

}
