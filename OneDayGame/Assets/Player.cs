using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FloatingJoystick joystick;
    public float moveSpeed = 100f;
    public float teleportSpeed = 100f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
    }

    public void Teleport(Vector3 teleportPosition)
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(teleportPosition.x,transform.position.y,teleportPosition.z), teleportSpeed);
    }
}
