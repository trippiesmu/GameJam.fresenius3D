using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;

    private float xInput;
    private float zInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        //Movement
        Move();
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            SceneManager.LoadScene("level");
        }
    }
}