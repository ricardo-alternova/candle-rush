using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialConfig : MonoBehaviour
{
    public MaterialsSettings[] allConfigs;

    public MaterialsSettings GetRandomMaterialSettings()
    {
        return allConfigs[Random.Range(0, allConfigs.Length)]; ;
    }
}
