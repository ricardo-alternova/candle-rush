using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GJam2020.Core
{
    public class PlayerPrefsMgr : MonoBehaviour
    {
        public static PlayerPrefsMgr _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                if (_instance != this)
                    DestroyImmediate(this);
            }
            else
            {
                _instance = this;
            }
        }

        public static PlayerPrefsMgr Get() { return _instance; }

        public void Save<T>(string key, object value)
        {
            Type typeOfT = typeof(T);

            if (typeOfT == typeof(string))
            {
                PlayerPrefs.SetString(key, value as string);
            }
            if (typeOfT == typeof(int))
            {
                PlayerPrefs.SetInt(key, (int)value);
            }
        }

        public int LoadInt(string key)
        {
            var value = PlayerPrefs.GetInt(key);
            return value;
        }
    }
}