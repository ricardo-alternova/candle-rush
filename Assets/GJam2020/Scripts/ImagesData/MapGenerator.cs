using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PairPositions
{
    public Vector3 Pos1;
    public Vector3 Pos2;
}

public class MapGenerator : MonoBehaviour
{
    public string FileName;
    private readonly string folderPath = Application.streamingAssetsPath + "/maps/";
    public GameObject GroundPrefab;
    public GameObject StartPrefab;
    public GameObject EndPrefab;
    public GameObject WallPrefab;
    public GameObject PiecePrefab;
    public GameObject Teleporter;
    public Transform Ground;

    public Color holeColor;
    public  Color groundColor;
    public Color wallColor;
    public Color startColor;
    public Color endColor;
    public Color pieceColor;

    private List<Vector3> _obstaclesPosition = new List<Vector3>();

    private Dictionary<Color, PairPositions> PairPositions = new Dictionary<Color, PairPositions>();


    public static MapGenerator Get;

    private void Awake()
    {
        Get = this;
    }

    public void Start()
    {
        ReadImage();
    }

    public void ReadImage()
    {
        byte[] imageData = File.ReadAllBytes(folderPath + FileName);
        Texture2D texture = new Texture2D(2,2);
        texture.LoadImage(imageData);
        GenerateCubesPerPixel(texture.width, texture.height, texture);
    }
    

    public void GenerateCubesPerPixel(int width, int height, Texture2D data,  int scale = 1)
    {
        Color[] colors = data.GetPixels();
        float fPos = 0;
        float cPos = 0;
        for(int f = 0; f < height; f++)
        {
            for(int c = 0; c < width; c++)
            {
                Color color = colors[((f * width) + c)];
                GameObject cube;
                switch(GetColorType(color))
                {
                    case 1:
                        _obstaclesPosition.Add(new Vector3(cPos, 0, fPos));
                        break;
                    case 2:
                        cube = Instantiate(GroundPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 0, fPos);
                        break;
                    case 3:
                        _obstaclesPosition.Add(new Vector3(cPos, 0, fPos));
                        cube = Instantiate(WallPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 0, fPos);
                        cube = Instantiate(WallPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 1, fPos);
                        cube = Instantiate(WallPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 2, fPos);

                        break;
                    case 4:
                        cube = Instantiate(StartPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 0, fPos);
                        break;
                    case 5:
                        cube = Instantiate(EndPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 0, fPos);
                        break;
                    case 6:
                        cube = Instantiate(GroundPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 0, fPos);
                        cube = Instantiate(PiecePrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 0, fPos);
                        break;
                    default:
                        cube = Instantiate(Teleporter, Ground);
                        cube.transform.position = new Vector3(cPos, 0, fPos);
                        cube.GetComponent<Teleporter>().SetColor(color);
                        print(PairPositions);
                        if(PairPositions.ContainsKey(color)) {
                            PairPositions[color].Pos2 = new Vector3(cPos, 0, fPos);
                            print(PairPositions[color]);
                        }
                        else
                        {
                            PairPositions[color] = new PairPositions() { Pos1 = new Vector3(cPos, 0, fPos) };
                            print(PairPositions[color]);
                            
                        }
                        break;
                }

                cPos += 1;
            }
            fPos += 1;
            cPos = 0;
        }
    }

    public List<Vector3> GetObstaclesPosition() {
        return _obstaclesPosition;
    }

    private int GetColorType(Color color)
    {
        if(color == holeColor)
            return 1;
        if(color == groundColor)
            return 2;
        if(color == wallColor)
            return 3;
        if(color == startColor)
            return 4;
        if(color == endColor)
            return 5;
        if(color == pieceColor)
            return 6;
        print("return 0");
        return 0;
    }

    public Vector3 GetPairPosition(Color color, Vector3 vector3)
    {
        if(PairPositions.ContainsKey(color)) {
            PairPositions pair = PairPositions[color];
            if(pair.Pos1 == vector3)
            {
                return pair.Pos2;
            }
            else
            {
                return pair.Pos1;
            }
        }
        return vector3;
    }
}
