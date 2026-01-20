using UnityEngine;

public class throwing : MonoBehaviour
{
    public Transform playerCam;
    public Transform throwPoint;
    public GameObject throwableItem;

    public int totalThrows;
    public float throwCooldown;

    public KeyCode throwingKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool isThrowing;




    void Start()
    {
        isThrowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwingKey) && isThrowing && totalThrows > 0)
        {
            Throw();
        }   
    }

    private void Throw()
    {
        isThrowing = false;

        GameObject throwInstantiation = Instantiate(throwableItem, throwPoint.position, playerCam.rotation);

        Rigidbody rb = throwInstantiation.GetComponent<Rigidbody>();

        LayerMask ignorePlayer = LayerMask.GetMask("Player");

        //raycast to shoot from center of screen instead of throwPoint
        Vector3 forceCenterScreen = playerCam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(playerCam.position, playerCam.forward, out hit, 500f, ignorePlayer))
        {
            forceCenterScreen = (hit.point - throwPoint.position).normalized;
            Debug.Log("Hit " + hit.collider.name);
        }

        Vector3 forceDirection = forceCenterScreen * throwForce + transform.up * throwUpwardForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ThrowReset), throwCooldown);

        Destroy(throwInstantiation, 5f);

    }

    private void ThrowReset()
    {
               isThrowing = true;
    }
}
