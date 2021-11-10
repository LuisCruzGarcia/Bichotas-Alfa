using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    [SerializeField]
    Transform grabDestination;
    bool trigger = false;

    private void OnMouseDown()
    {
        this.transform.position = grabDestination.position;
        this.transform.parent = GameObject.Find("GrabPoint").transform;
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
    }

    private void Update()
    {
        if (Input.GetButtonDown("z"))
        {
            if (trigger)
            {
                trigger = false;
            }
            else
            {
                trigger = true;
            }
            Debug.Log(trigger);
            Debug.Log("Z");
        }
    }
}