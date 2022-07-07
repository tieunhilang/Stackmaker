using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StackScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            other.gameObject.tag = "normal";
            PlayerController.Instance.PickStack(other.gameObject);
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackScript>();
            Destroy(this);

        }
        if (other.tag == "UnPickup")
        {
            
            PlayerController.Instance.DropStack();
            Destroy(other.gameObject);
        }
    }
}
