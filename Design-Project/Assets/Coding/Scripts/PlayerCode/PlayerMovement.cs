using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour
{

    List<Vector3> desiredPostions = new List<Vector3>();

    public GameObject arrow;
    public GameObject arrowPlane;
    public Transform arrowStart;
    public Transform arrowEnd;
    public TMP_Text arrowText;
    public GameObject Goal;

    public float maxAmount = 4;
    public float speed = 0.06f;
    public int amount;

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

    private void Start()
    {
        arrowText.text = "X" + (maxAmount - amount).ToString();
    }

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
            if (Input.GetButton("Fire1"))
            {
                arrow.transform.localScale += new Vector3(0, 0, Time.deltaTime);
            }
            else
            {
                arrow.transform.Rotate(new Vector3(0f, -0.6f, 0f));
            }

            if (Input.GetButtonUp("Fire1"))
            {
                PlaceArrows();
                arrow.transform.localScale = new Vector3(1, 1, 1);
            }

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
            var tempArrow = Instantiate(arrowPlane, arrow.transform.position, arrow.transform.rotation);
            tempArrow.transform.localScale = arrow.transform.localScale;
            amount++;
            arrow.transform.position = arrowEnd.transform.position;
            arrowText.text = "X" + (maxAmount - amount).ToString();
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
        try
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
        catch (ArgumentOutOfRangeException e)
        {
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (amount == maxAmount)
        {
            if (other.gameObject.CompareTag("goal"))
            {
                other.transform.localScale = Vector3.one;
                Debug.Log("Din mamma har vunnit");
            }
        }
    }
}
