using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject particleEffect;
    [SerializeField] AudioClip collectSFX;
    [SerializeField] AudioClip winSFX;

    [SerializeField] MultipleTargetCamera cam;
    public bool isEndPoint;


    private void Update()
    {
        if (isEndPoint)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            if(cam.targets.Count == 2)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }

    }

    private void OnMouseDown()
    {
        player.Teleport(transform.position);
        gameObject.GetComponent<AudioSource>().PlayOneShot(collectSFX,1f);
        var vfx = Instantiate(particleEffect, transform.position, Quaternion.identity)as GameObject;
        Destroy(vfx, 6f);
        if (isEndPoint)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(winSFX, 1f);
            GameController.instance.LevelWin();
            
            Destroy(gameObject,0.5f);
        }
        else
        {
            Destroy(gameObject, 0.2f);
        }
        
        
    }

  
}
