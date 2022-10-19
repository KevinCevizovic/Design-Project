using UnityEngine.SceneManagement;
using UnityEngine;

public class Win : MonoBehaviour
{
    public LayerMask mask;
    PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 0.6f, transform.forward, 0.6f, mask);

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("You Died");
            }
        }
        if (movement.moveDone)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("Goal"))
                {
                    Debug.Log("Win!");
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.6f);
    }
}
