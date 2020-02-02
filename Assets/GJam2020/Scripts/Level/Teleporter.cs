using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Avatar;

public class Teleporter : MonoBehaviour
{
    private Vector3 _localPosition;
    private Color _localColor;
    // Start is called before the first frame update
    void Start()
    {
        _localPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(AvatarPosition.CanTeleporter)
        {
            AvatarPosition.CanTeleporter = false;
            StartCoroutine(AvatarPosition.Teleporter());
            other.transform.position = MapGenerator.Get.GetPairPosition(_localColor, _localPosition);
        }
    }

    public void SetColor(Color color)
    {
        _localColor = color;
    }
}
