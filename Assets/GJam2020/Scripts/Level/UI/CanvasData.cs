using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GJam2020.Avatar;

namespace GJam2020.Core {
    public class CanvasData : MonoBehaviour
    {
        
        public Text NumberOfPieces;
        public Text Time;
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

        public void SetTime(float time)
        {
            time = Mathf.Floor(time);
            Time.text = time + "";
        }

        
        //public void Dead()
        //{
        //    panelDead.SetActive(true);
        //}

        //public void Restore()
        //{
        //    print("restore");
        //    panelDead.SetActive(false);
        //    GameManager.Get.Restore();
        //}
    }
}
