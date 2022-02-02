using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 input;
    private Rigidbody rb;
    private PlayerCamera cam;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float jump = 4f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<PlayerCamera>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    private void MovePlayer()
    {
        transform.forward = cam.transform.forward;
        Vector3 directionX = transform.right.normalized * input.x;
        Vector3 directionZ = transform.forward.normalized * input.z;
        rb.velocity = new Vector3(0, rb.velocity.y, 0) + (directionX + directionZ) * speed;
    }
}
