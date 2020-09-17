using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestingPortals
    {
        
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
        public IEnumerator TestingPortalsWithEnumeratorPasses()
        {
            // Get Scriptable to get Color
            MapGeneratorSettings setting = Resources.Load<MapGeneratorSettings>("Common_Map");
            List<string> ColorsList = new List<string>();
            foreach(ColorPrefabRelation relation in setting.prefabs)
            {
                if (relation.Entity != MapEntity.teleporter)
                {
                    ColorsList.Add(relation.Color.ToString());
                    Debug.Log(relation.Color + " " + relation.Entity.ToString());
                }
            }
            ColorsList.Add(new Color(1, 1, 1).ToString());

            string Path = Application.dataPath+"/GJam2020/LevelDesigns/";
            string[] files = Directory.GetFiles(Path);
            
            foreach(string pathFile in files)
            {
                string [] parts = pathFile.Split('.');
                if (parts[parts.Length - 1] == "png")
                {
                    Dictionary<string, int> counter = new Dictionary<string, int>();
                    // Test Read Image
                    Texture2D tex = null;
                    byte[] fileData;
                    if (File.Exists(pathFile))
                    {
                        //Debug.Log(pathFile);
                        fileData = File.ReadAllBytes(pathFile);
                        tex = new Texture2D(2, 2);
                        tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                        Color[] colors = tex.GetPixels();
                        for (int f = 0; f < tex.height; f++)
                        {
                            for (int c = 0; c < tex.width; c++)
                            {
                                Color color = colors[((f * tex.width) + c)];
                                if (!ColorsList.Contains(color.ToString()))
                                {
                                    if (counter.ContainsKey(color.ToString()))
                                    {
                                        counter[color.ToString()] += 1;
                                    }
                                    else
                                    {
                                        counter[color.ToString()] = 1;
                                    }
                                }

                            }
                        }                         
                    }
                    foreach (KeyValuePair<string, int> count in counter)
                    {
                        if(count.Value % 2 != 0)
                        {
                            Debug.Log("Here");
                        }
                        Assert.IsTrue(count.Value % 2 == 0, "Color " + count.Key + "is not balanced in "+pathFile+" Counter is " +count.Value);

                    }
                }
            }
            
            
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
