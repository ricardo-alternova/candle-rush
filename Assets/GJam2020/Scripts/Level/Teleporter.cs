using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        other.transform.position=MapGenerator.Get.GetPairPosition(_localColor, _localPosition);
    }

    public void SetColor(Color color)
    {
        _localColor = color;
    }
}
