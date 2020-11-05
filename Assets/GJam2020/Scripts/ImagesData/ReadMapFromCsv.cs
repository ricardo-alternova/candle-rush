using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadMapFromCsv : MonoBehaviour
{
    private void Start()
    {
        GetColorFromCsv("24");
    }
    public Color[] GetColorFromCsv(string name)
    {
        List<Color> colorList = new List<Color>();
        string path = "Assets/Resources/{0}.csv";
        string text = File.ReadAllText(string.Format(path, name));
        string[] lines = text.Split('\n');
        int lineCount = 0;
        foreach(string line in lines)
        {
            string[] colors = line.Split(',');
            foreach(string color in colors)
            {
                string[] parts = color.Split('-');
                if (parts.Length > 0)
                {
                    try
                    {
                        colorList.Add(new Color(
                            float.Parse(parts[0]),
                            float.Parse(parts[1]),
                            float.Parse(parts[2])
                            ));
                    }
                    catch
                    {
                        Debug.Log("line"+lineCount);
                        Debug.Log(parts[0]);
                    }
                }
                
            }
            lineCount++;
        }

        return colorList.ToArray();
    }
}
