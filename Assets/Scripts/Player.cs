using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public CameraController camera;
    public float moveSpeed = 10f;
    private float xInput;
    private float zInput;
    public float jumpForce = 0.2f;
    public int coins = 0;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody>();
        Debug.Log("Player has awoken");
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.tag);
    }

    // Update is called once per frame
    void Update(){
     ProcessInputs(); 
    }

    private void FixedUpdate(){
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround()){
            Jump();
        }
        camera.zOffSet += Input.mouseScrollDelta.y;
        camera.zOffSet = camera.zOffSet > -3f ? -3f : camera.zOffSet;
    }

    private void rotateLeft(){
        transform.Rotate(0, -1, 0);
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
    /*Para que no salte en el aire*/
    private bool isOnGround(){
        return Physics.Raycast(transform.position, Vector3.down, 1f);
    }
    private void ScallingDown(float scale){
        transform.localScale -= new Vector3(scale, scale, scale);
    }
    private void ScallingUp(float scale){
        transform.localScale += new Vector3(scale, scale, scale);
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.name.Contains("Moneda")){
            coins++;
        }
        if (other.gameObject.name.Contains("Jumper")){
            JumpHightPerTime(8);
        }
        if (other.gameObject.name.Contains("Smaller")){
            ScallingDown(1.5f);
        }
        if (other.gameObject.name.Contains("Bigger")){
            ScallingUp(1.5f);
        }
        if (other.gameObject.name.Contains("Slime")){
            transform.position = new Vector3(0, 0, 0);
        }
    }
    void JumpHightPerTime(int time){
        for (int i = 0; i < time; i++){
            Jump();
        }
    }

}
