using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAsignable : MonoBehaviour
{
    public string materialName;
    // Start is called before the first frame update
    void Start()
    {
        Material nMaterial = GameManager.Get.materialsSettings.GetMaterial(materialName);
        gameObject.GetComponent<Renderer>().material = nMaterial;
    }

}
