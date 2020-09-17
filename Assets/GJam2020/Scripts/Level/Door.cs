using GJam2020.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public int linkIndex;
    [SerializeField] public Transform keyBone;
    [HideInInspector] public bool rotate;
    [SerializeField] private AudioClip doorClip;
    private AudioSourcePlayer fxPlayer;
    private bool opened = false;

    private void Start()
    {
        StartCoroutine(Initialize());
        fxPlayer = SoundManager.Get().FxPlayer;
    }

    private IEnumerator Initialize()
    {
        Transform parent = transform.GetComponentsInParent<Transform>()[1];
        Transform[] blocks = parent.GetComponentsInChildren<Transform>();
        List<Vector3> nearBlocks = new List<Vector3>();
        rotate = true;
        foreach (var item in blocks)
        {
            float distance = Vector3.Distance(new Vector3(item.position.x, 0, item.position.z), new Vector3(transform.position.x, 0, transform.position.z));
            if (distance <= 1.1f && distance> 0.1f && (item.name == "NormalGround2(Clone)" || item.name == "Teleporter(Clone)" || item.name == "End(Clone)" || item.name == "IceGround(Clone)"))
            {
                nearBlocks.Add(item.position);
            }
        }
        foreach (var item in nearBlocks)
        {
            if (item.x != transform.position.x )
            {
                rotate = false;
            }
        }
        if (!rotate)
        {
            transform.localEulerAngles += new Vector3(0, 90, 0);
        }
        yield return new WaitForSeconds(1);
        Key[] keys = parent.GetComponentsInChildren<Key>();
    }
    public void Open()
    {
        opened = true;
        fxPlayer.PlayOneShot(doorClip);
        MapGenerator.Get.RemoveObstacle(transform.position);
        GetComponentInChildren<Animator>().SetTrigger("Open");
        GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_Open", 0.2f);
    }
    public void Close()
    {
        if (!opened) return;
        opened = false;
        MapGenerator.Get.AddObstacle(transform.position);
        GetComponentInChildren<Animator>().SetTrigger("Close");
        GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_Open", 0f);
    }
}
