using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private GameObject focalPoint;

    [SerializeField]
    private float playerSpeed = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerForward();
    }

    void MovePlayerForward()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRigidbody.AddForce(focalPoint.transform.forward * playerSpeed * forwardInput);
    }
}
