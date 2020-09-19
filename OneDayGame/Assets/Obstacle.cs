using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject playerDeathVFX;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Debug.Log("Collision Detected!");
            //Game Has Ended
            //play death vfx
            var vfx = Instantiate(playerDeathVFX, other.gameObject.GetComponent<Player>().transform.position,
                Quaternion.identity);
            Destroy(vfx, 2f);
            GameController.instance.RestartLevel();
            
        }
    }
}
