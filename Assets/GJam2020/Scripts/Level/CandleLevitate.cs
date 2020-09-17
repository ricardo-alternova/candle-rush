using UnityEngine;

public class CandleLevitate : MonoBehaviour
{
    [SerializeField]
    private float _multiplier = 0.15f;
    private Vector3 _position;
    private Vector3 _initialPosition;

    private void Start()
    {
        _position = Vector3.zero;
        _initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        _position.y = Mathf.Sin(Time.time) * _multiplier;
        transform.localPosition = _position + _initialPosition;
    }
}
