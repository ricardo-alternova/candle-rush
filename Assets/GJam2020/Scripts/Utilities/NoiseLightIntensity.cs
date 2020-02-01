using UnityEngine;

public class NoiseLightIntensity : MonoBehaviour
{
    private Light light;
    private float intensity;
    [SerializeField]
    private float multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        intensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = Mathf.PerlinNoise(Time.time, Time.time) * multiplier + intensity;
    }
}
