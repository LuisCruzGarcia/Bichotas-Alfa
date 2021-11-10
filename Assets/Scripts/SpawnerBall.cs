using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBall : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    public GameObject ballInteractable;

    private void Start()
    {
        ballInteractable = Instantiate(ball, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(ballInteractable == null)
        {
            ballInteractable = Instantiate(ball, transform.position, Quaternion.identity);
        }
    }
}
