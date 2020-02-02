using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GJam2020.Avatar;

namespace GJam2020.Core {
    public class CanvasData : MonoBehaviour
    {
        public PlayerMovement playerMovement;
        public Text NumberOfPieces;
        public GameObject panelDead;

        public static CanvasData Get;

        private void Awake()
        {
            Get = this;
        }

        public void SetNumberOfPieces(int pieces)
        {
            NumberOfPieces.text = pieces + "";
        }

        public void Dead()
        {
            panelDead.SetActive(true);
        }

        public void Restore()
        {
            panelDead.SetActive(false);
            CommandsManager.Instance.StartRewindCommands(playerMovement, (() => Debug.Log("Rewind finished")));
        }
    }
}
