using GJam2020.Core;
using UnityEngine;

public class AudioClipSetterOnAwake : MonoBehaviour
{
    [SerializeField]
    private AudioSourcePlayer player;

    private void Awake()
    {
        AudioClip clip = GameManager.Get.currentLevel.SoundBackground;
        if (clip != null)
        {
            player.Clip = clip;
            player.Play();
        }
    }
}
