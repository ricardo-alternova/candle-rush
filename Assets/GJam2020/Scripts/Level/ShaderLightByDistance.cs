using UnityEngine;
using UnityEngine.Assertions;

public class ShaderLightByDistance : MonoBehaviour
{
    private Transform _avatarTransform;
    // Start is called before the first frame update
    void Start()
    {
        _avatarTransform = GameObject.Find("WaxBoy").GetComponent<Transform>();
        Assert.IsNotNull(_avatarTransform, "WasBoy GameObject not found");
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_AVATARposition", _avatarTransform.position);
    }
}
