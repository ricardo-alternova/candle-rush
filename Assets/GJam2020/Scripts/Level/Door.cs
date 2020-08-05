using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int linkIndex;

    private void Start()
    {
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        Transform parent = transform.GetComponentsInParent<Transform>()[1];
        Transform[] blocks = parent.GetComponentsInChildren<Transform>();
        List<Vector3> nearBlocks = new List<Vector3>();
        bool rotate = false;
        foreach (var item in blocks)
        {
            float distance = Vector3.Distance(new Vector3(item.position.x, 0, item.position.z), new Vector3(transform.position.x, 0, transform.position.z));
            if (distance <= 1.1f && distance> 0.1f)
            {
                nearBlocks.Add(item.position);
            }
        }
        foreach (var item in nearBlocks)
        {
            if (item.x != transform.position.x )
            {
                rotate = true;
            }
        }
        if (rotate)
        {
            transform.localEulerAngles += new Vector3(0, 90, 0);
        }
        yield return new WaitForSeconds(1);
        Key[] keys = parent.GetComponentsInChildren<Key>();
        foreach (var item in keys)
        {
            item.TakeKey += Open;
        }
    }
    public void Open(int index)
    {
        if (index == linkIndex)
        {
            MapGenerator.Get.RemoveObstacle(transform.position);
            transform.position += transform.right;
        }
    }
}
