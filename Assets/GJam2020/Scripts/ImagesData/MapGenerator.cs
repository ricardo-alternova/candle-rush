using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PairPositions
{
    public Vector3 Pos1;
    public Vector3 Pos2;
}

public class MapGenerator : MonoBehaviour
{
    public Vector3 StartPosition { get; private set; }

    public GameObject GroundPrefab;
    public GameObject StartPrefab;
    public GameObject EndPrefab;
    public GameObject WallPrefab;
    public GameObject PiecePrefab;
    public GameObject Teleporter;
    public Transform Ground;

    public Color holeColor;
    public Color groundColor;
    public Color wallColor;
    public Color startColor;
    public Color endColor;
    public Color pieceColor;

    public UnityEvent OnSceneCreated;

    private LevelSettings settings;
    private List<Vector3> _obstaclesPosition = new List<Vector3>();

    private Dictionary<Color, PairPositions> PairPositions = new Dictionary<Color, PairPositions>();


    public static MapGenerator Get;

    private void Awake()
    {
        settings = GameManager.Get.currentLevel;
        Get = this;
    }

    private void Start()
    {
        ReadImage();
    }

    public void ReadImage()
    {
        Texture2D texture = settings.Map;
        GenerateCubesPerPixel(texture.width, texture.height, texture);
        OnSceneCreated.Invoke();
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
                    case MapEntity.hole:
                        _obstaclesPosition.Add(new Vector3(cPos, -.5f, fPos));
                        break;
                    case MapEntity.ground:
                        cube = Instantiate(GroundPrefab, Ground);
                        //cube.GetComponent<Renderer>().sharedMaterial = GroundPrefab.GetComponent<Renderer>().sharedMaterial;
                        cube.transform.position = new Vector3(cPos, -.5f, fPos);
                        break;
                    case MapEntity.wall:
                        _obstaclesPosition.Add(new Vector3(cPos, -.5f, fPos));
                        cube = Instantiate(WallPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, -.5f, fPos);
                        cube = Instantiate(WallPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, .5f, fPos);
                        cube = Instantiate(WallPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, 1.5f, fPos);

                        break;
                    case MapEntity.startFlag:
                        cube = Instantiate(StartPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, -0.5f, fPos);
                        StartPosition = cube.transform.position + new Vector3(0, 0.5f, 0);
                        break;
                    case MapEntity.endFlag:
                        cube = Instantiate(EndPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, -0.5f, fPos);
                        break;
                    case MapEntity.teleporter:
                        cube = Instantiate(GroundPrefab, Ground);
                        cube.transform.position = new Vector3(cPos, -0.5f, fPos);
                        cube = Instantiate(PiecePrefab, Ground);
                        cube.transform.position = new Vector3(cPos, .5f, fPos);
                        break;
                    default:
                        cube = Instantiate(Teleporter, Ground);
                        cube.transform.position = new Vector3(cPos, -0.5f, fPos);
                        cube.GetComponent<Teleporter>().SetColor(color);
                        print(PairPositions);
                        if(PairPositions.ContainsKey(color)) {
                            PairPositions[color].Pos2 = new Vector3(cPos, -0.5f, fPos);
                            print(PairPositions[color]);
                        }
                        else
                        {
                            PairPositions[color] = new PairPositions() { Pos1 = new Vector3(cPos, -0.5f, fPos) };
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

    public enum MapEntity { hole, ground, wall, endFlag, startFlag, teleporter, other}

    public Vector3 GetPairPosition(Color color, Vector3 vector3)
    {
        if(PairPositions.ContainsKey(color)) {
            PairPositions pair = PairPositions[color];
            if(pair.Pos1 == vector3)
            {
                return pair.Pos2+new Vector3(0f,.5f,0f);
            }
            else
            {
                return pair.Pos1 + new Vector3(0f, .5f, 0f);
            }
        }
        return vector3;
    }

    private MapEntity GetColorType(Color color)
    {
        if(color == holeColor)
            return MapEntity.hole;
        if(color == groundColor)
            return MapEntity.ground;
        if(color == wallColor)
            return MapEntity.wall;
        if(color == startColor)
            return MapEntity.startFlag;
        if(color == endColor)
            return MapEntity.endFlag;
        if(color == pieceColor)
            return MapEntity.teleporter;
        print("return 0");
        return MapEntity.other;
    }
}
