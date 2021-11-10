using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    GameObject bounceSurface;

    Transform positionIdentity;

    // Start is called before the first frame update
    void Start()
    {
        positionIdentity = GameObject.Find("GrabPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(positionIdentity.forward * bulletSpeed * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Instantiate(bounceSurface, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
