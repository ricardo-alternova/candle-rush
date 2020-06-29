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
    private Dictionary<string,Material> materialsDict;

    public Material GetMaterial(string name)
    {
        if (materialsDict==null || materialsDict.Count==0)
        {
            Initialize();
        }
        return materialsDict[name];
    }
    private void Initialize()
    {
        materialsDict = new Dictionary<string, Material>();
        foreach(MaterialNameStruc material in materials) 
        {
            materialsDict[material.Name] = material.material;
        }
    }
}