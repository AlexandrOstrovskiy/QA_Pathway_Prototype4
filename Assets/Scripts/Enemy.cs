using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.4f;

    private Rigidbody enemyRigidbody;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();

    }

    void FollowPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(lookDirection * speed * Time.deltaTime);
    }
}
