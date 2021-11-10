using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    //Usable
    [SerializeField]
    private Camera characterCamera;
    bool trigger = false;

    //Pickable Object
    [SerializeField]
    private Transform slot;
    private PickableItem pickedItem;

    //Shoot variables
    [SerializeField]
    private GameObject bullet;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Escape");
            if (trigger)
            {
                trigger = false;
            }
            else
            {
                trigger = true;
            }
        }

        if (trigger)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RayCastPickable();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootBounceSurface();
            }
        }
    }

    private void RayCastPickable()
    {
        if (pickedItem)
        {
            DropItem(pickedItem);
        }
        else
        {
            var ray = characterCamera.ViewportPointToRay(Vector3.one * .5f);
            RaycastHit hit;
            // Shot ray to find object to pick
            if (Physics.Raycast(ray, out hit, 1.5f))
            {
                // Check if object is pickable
                var pickable = hit.transform.GetComponent<PickableItem>();

                if (pickable)
                {
                    PickItem(pickable);
                }
            }
        }
    }

    private void PickItem(PickableItem item)
    {
        // Assign reference
        pickedItem = item;
        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        // Set Slot as a parent
        item.transform.SetParent(slot);
        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
    }

    private void DropItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;
        // Remove parent
        item.transform.SetParent(null);
        // Enable rigidbody
        item.Rb.isKinematic = false;
        // Add force to throw item a little bit
        item.Rb.AddForce(item.transform.forward * 5, ForceMode.VelocityChange);
    }

    private void ShootBounceSurface()
    {
        Instantiate(bullet, slot.transform.position, Quaternion.identity);
    }
}
