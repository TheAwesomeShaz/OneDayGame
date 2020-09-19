using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public Vector3 singleTargetOffset;
    public float smoothSpeed = 0.25f;


    public bool lookAtPlayer;

    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
            
        //TODO instead of count == 1 check if game has ended
        if(targets.Count == 1)
        {
            offset = singleTargetOffset;
        }

        Vector3 centerPoint = GetCenterPoint();

        Vector3 desiredPos = centerPoint + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
    }

    private void Update()
    {
        RemoveDeletedTargets();
        if (lookAtPlayer)
        {
            LookatPlayerOnly();
        }
    }

    private void RemoveDeletedTargets()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (!targets[i])
            {
                targets.RemoveAt(i);
            }
        }
    }

    private void LookatPlayerOnly()
    {
        for (int i = 1; i < targets.Count; i++)
        {
                targets.RemoveAt(i);   
        }
    }

    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i])
            {
                bounds.Encapsulate(targets[i].position);
            }
            
        }
        return bounds.center;
    }
}
