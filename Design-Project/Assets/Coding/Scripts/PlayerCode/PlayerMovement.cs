using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    List<Vector3> desiredPostions = new List<Vector3>();

    public GameObject arrow;
    public GameObject arrowPlane;
    public Transform arrowStart;
    public Transform arrowEnd;
    public float maxAmount = 4;
    public float speed = 0.06f;

    bool move = false;

    private float Speed
    {
        get
        { return speed; }
        set
        {
            if (value > 0.06) speed = 0.06f;
            else
            {
                speed = value;
            }
        }
    }
    public int amount;
    public float waitTime = 2f;

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Speed = Mathf.Lerp(Speed, 0.01f, Time.deltaTime * 20);
        }
        else
        {
            Speed = Mathf.Lerp(Speed, 0.06f, Time.deltaTime * 20);
        }

        if (amount < maxAmount)
        {
            arrow.transform.Rotate(new Vector3(0f, -0.6f, 0f));
        }
        else
        {
            arrow.GetComponent<MeshRenderer>().enabled = false;
        }
        
        if (desiredPostions.Count >= 4)
        {
            move = true;
        }
        if (move)
        {
            Play();
        }
    }

    public void PlaceArrows()
    {
        if (amount < maxAmount)
        {
            Instantiate(arrowPlane, arrow.transform.position, arrow.transform.rotation);
            amount++;
            arrow.transform.position = arrowEnd.transform.position;

            // Add positions to list
            desiredPostions.Add(arrowStart.transform.position);

            foreach (var item in desiredPostions)
            {
                Debug.Log(item);
            }
        }
    }

    // Make the player move to the desired positions
    public void Play()
    {
        transform.rotation = Quaternion.LookRotation(desiredPostions[0] - transform.position);
        // Move to the first position
        transform.position = Vector3.MoveTowards(transform.position, desiredPostions[0], Speed);

        // If the player is at the first position
        if (transform.position == desiredPostions[0])
        {
            // Remove the first position from the list
            desiredPostions.RemoveAt(0);
        }
    }

    public void SlowDown()
    {
        
    }
}
