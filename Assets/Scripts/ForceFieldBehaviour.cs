using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ForceFieldObject"))
        {
            Destroy(this.gameObject);
        }
    }
}