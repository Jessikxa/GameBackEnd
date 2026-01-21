using UnityEngine;

public class PickUpItem : MonoBehaviour
{


    bool isPickedUp;
    bool isHolding;
    [SerializeField] Transform objectShownOnScreen;
    Rigidbody rb;
    



    void Start()
    {
        rb = this.GetComponent<Rigidbody>();  //the this. could maybe be removed
    }

    // Update is called once per frame
    void Update()
    {
        //spin object when not held
        if (!isHolding)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 50f, Space.World); //or Space.Self
        }

        if (Input.GetKeyDown(KeyCode.E) && isPickedUp)
        {
            if (!isHolding)
                Pick();
            else
                Drop();
        }
       
    }

    void Pick()
    {
        isHolding = true;
        rb.isKinematic = true;
        transform.SetParent(objectShownOnScreen);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

    }

    void Drop()
    {
        isHolding = false;
        rb.isKinematic = false;
        transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
            isPickedUp = true;
            Debug.Log("Trigger entered by " + other.name);
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Player"))

        //{
            isPickedUp = false;
        //}
    }
}
