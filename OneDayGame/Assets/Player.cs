using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject playerDeathVFX;
    [SerializeField] AudioClip deathSFX;
    public FloatingJoystick joystick;
    //public float moveSpeed = 100f;
    public float teleportSpeed = 100f;
    public Transform spawnPoint;
    Rigidbody rb;
    bool isMoving;
    bool sfxPlayed;
    Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (GameController.instance.isDead)
        {
            isMoving = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (!sfxPlayed)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(deathSFX, 1f);
                sfxPlayed = true;
            }
            return;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            //this one is visually appealing but collisions not working
            rb.position = Vector3.MoveTowards(transform.position,
                newPos, teleportSpeed * Time.deltaTime);
            
        }
    }

    public void Teleport(Vector3 teleportPosition)
    {
        

        newPos = new Vector3(teleportPosition.x, transform.position.y, teleportPosition.z);
        isMoving = true;
        //teleporting through rb to enable collisions
        //rb.position = Vector3.Lerp(transform.position,
        //    newPos, teleportSpeed * Time.deltaTime);


    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Obstacle")
        {
            //Game Has Ended
            //play death vfx
            var vfx = Instantiate(playerDeathVFX, other.gameObject.GetComponent<Player>().transform.position,
                Quaternion.identity);
            Destroy(vfx, 2f);
            GameController.instance.RestartLevel();

        }
    }

}
