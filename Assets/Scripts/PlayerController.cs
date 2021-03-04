using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private GameObject focalPoint;

    public GameObject powerUpIndicator;

    [SerializeField]
    private float playerSpeed = 5.5f;

    [SerializeField]
    private bool hasPowerUp;

    [SerializeField]
    private float powerUpDamageStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        powerUpIndicator.transform.position = transform.position + new Vector3(0, 2.0f, 0);
        MovePlayerForward();
    }

    void MovePlayerForward()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRigidbody.AddForce(focalPoint.transform.forward * playerSpeed * Time.deltaTime * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("FATALITY");

            enemyRigidbody.AddForce(awayFromPlayer * powerUpDamageStrength * 50 * Time.deltaTime, ForceMode.Impulse);;

        }

    }
}
