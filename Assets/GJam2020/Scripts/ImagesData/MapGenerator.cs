using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    public Transform Ground;
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
                GameObject instance;

                ColorPrefabRelation colorPrefab = settings.MapSettings.GetPrefab(color);

                if (colorPrefab != null)
                {
                    if (colorPrefab.IsObstacle)
                        _obstaclesPosition.Add(new Vector3(cPos, -.5f, fPos));

                    if (!colorPrefab.IsEmpty)
                    {
                        instance = InstantiateAndLocate(colorPrefab, fPos, cPos);

                        if (colorPrefab.UseGround)
                            InstantiateAndLocate(settings.MapSettings.Ground, fPos, cPos);

                        if (colorPrefab.UsePairPosition)
                            SetPairPosition(colorPrefab, fPos, cPos);

                        switch (colorPrefab.Entity)
                        {
                            case MapEntity.startFlag:
                                StartPosition = new Vector3(cPos, 0f, fPos);
                                break;
                            case MapEntity.teleporter:
                                instance.GetComponent<Teleporter>().SetColor(color);
                                break;
                        }
                    }
                }

                cPos += 1;
            }
            fPos += 1;
            cPos = 0;
        }
    }

    private void SetPairPosition(ColorPrefabRelation colorPrefab, float fPos, float cPos)
    {
        if (PairPositions.ContainsKey(colorPrefab.Color))
            PairPositions[colorPrefab.Color].Pos2 = new Vector3(cPos, -0.5f, fPos);
        else
            PairPositions[colorPrefab.Color] = new PairPositions() { Pos1 = new Vector3(cPos, -0.5f, fPos) };
    }

    private GameObject InstantiateAndLocate(ColorPrefabRelation colorPrefab, float fPos, float cPos)
    {
        GameObject instance = Instantiate(colorPrefab.Prefab, Ground);
        instance.transform.position = new Vector3(cPos, colorPrefab.Offset, fPos);
        return instance;
    }

    public List<Vector3> GetObstaclesPosition() {
        return _obstaclesPosition;
    }

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
}
