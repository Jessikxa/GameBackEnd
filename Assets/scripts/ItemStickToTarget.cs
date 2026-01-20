using UnityEngine;

public class ItemStickToTarget : MonoBehaviour
{
    private Rigidbody rb;

    private bool targetHit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //targetHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetHit) 
            return;
        //else
            targetHit = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.detectCollisions = false;

        // Stick to target
        rb.isKinematic = true;

        //transform.SetParent(collision.transform);
        //transform.localScale = Vector3.one;
    }

}
