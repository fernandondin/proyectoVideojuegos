using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;
    private float xInput;
    private float zInput;
    public float jumpForce = 0.2f;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
     ProcessInputs(); 
    }

    private void FixedUpdate(){
        Move();
        if (Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    private void ProcessInputs(){
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

    }
    private void Move(){
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }
    private void Jump(){
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
