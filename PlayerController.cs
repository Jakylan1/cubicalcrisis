using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float rotationSpeed = 10;
    public AudioClip soundClip_pop;

    private Rigidbody rb;
    private Vector3 lastDirection = Vector3.forward; // Store the last movement direction

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        EarnFromCubicle();

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = direction * moveSpeed;

        // Rotate the player to face the movement direction
        if (direction != Vector3.zero)
        {
            lastDirection = direction; // Update the last movement direction
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // If no movement input, maintain facing direction based on the last movement direction
            Quaternion targetRotation = Quaternion.LookRotation(lastDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void EarnFromCubicle()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.canPlayerEarnMoneyFromCubicle)
        {
            GameManager.Instance.playerMoney += 5;
            SoundManager.PlaySound(soundClip_pop);
        }
    }

}
