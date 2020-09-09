using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject particleEffect;

    private void OnMouseDown()
    {
        player.Teleport(transform.position);
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
