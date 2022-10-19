using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public LayerMask mask;
    private void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5, transform.forward, 0.75f, mask);

        foreach (var hit in hits)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.75f);
    }
}
