using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MaterialSettings", menuName = "ScriptableObjects/MaterialsSettings", order = 1)]
public class MaterialsSettings : ScriptableObject
{
    [System.Serializable]
    public struct MaterialNameStruc {
        public string Name;
        public Material material;
    }
    public MaterialNameStruc[] materials;
    public Material SkyboxMaterial;

    public Material GetMaterial(string name)
    {
        foreach(MaterialNameStruc material in materials)
        {
            if (material.Name == name)
            {
                return material.material;
            }
        }
        return null;
    }
    //public void Initialize()
    //{
    //    materialsDict = new Dictionary<string, Material>();
    //    foreach(MaterialNameStruc material in materials) 
    //    {
    //        materialsDict[material.Name] = material.material;
    //    }
    //}
}