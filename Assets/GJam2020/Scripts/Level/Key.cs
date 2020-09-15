using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private int linkIndex;

    private Transform player;

    private Door myDoor;

    private bool taked;

    private int avatarLayer;

    private void Awake()
    {
        avatarLayer = LayerMask.NameToLayer("Avatar");
    }

    private void Update()
    {
        if (taked)
        {
            if (Vector3.Distance(player.position, myDoor.transform.position) <= 1.5f)
            {
                taked = false;
                GetComponent<FloatingObjects>().enabled = false;
                StartCoroutine(OpenCorroutine());
            }
            transform.position = new Vector3(player.position.x + 0.3f, transform.position.y, player.position.z - 0.3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != avatarLayer) return;
        foreach (var item in transform.parent.GetComponentsInChildren<Door>())
        {
            if (item.linkIndex == linkIndex)
            {
                myDoor = item;
                break;
            }
        }
        player = other.transform;
        taked = true;
        GetComponent<Collider>().enabled = false;
    }

    IEnumerator OpenCorroutine()
    {
        Vector3 target = myDoor.keyBone.position;
        Vector3 targetRot;
        if (myDoor.rotate)
        {
            if (player.position.z > myDoor.transform.position.z)
            {
                targetRot = Vector3.forward;
            }
            else
            {
                targetRot = Vector3.back;
            }
        }
        else
        {
            if (player.position.x < myDoor.transform.position.x)
            {
                targetRot = Vector3.left;
            }
            else
            {
                targetRot = Vector3.right;
            }
        }
        while (Vector3.Distance(transform.position, target) >= 0.01f || transform.forward != targetRot)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.02f);
            if (transform.forward != targetRot)
            {
                transform.forward = Vector3.MoveTowards(transform.forward, targetRot, 0.05f);
            }
            yield return new WaitForEndOfFrame();
        }
        transform.SetParent(myDoor.keyBone);
        myDoor.Open();
    }
}
