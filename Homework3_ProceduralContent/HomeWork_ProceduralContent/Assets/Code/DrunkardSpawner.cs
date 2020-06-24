﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace levelGenerator
{
    public class DrunkardSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _worldGrid;
        [SerializeField] private GameObject _drunkardLayer;
        [SerializeField] private GameObject _drunkard;

        public void StartDrunkard()
        {
            int width;
            int height;
            
            height = _worldGrid.GetComponent<WorldGrid>().Height;
            width = _worldGrid.GetComponent<WorldGrid>().Width;
            
            Instantiate(_drunkard, _drunkardLayer.transform);
        }
    }
}


