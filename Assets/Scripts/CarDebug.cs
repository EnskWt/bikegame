using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDebug : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Car")
        {
            Destroy(other.gameObject);
        }
    }
}
