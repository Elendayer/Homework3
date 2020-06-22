using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace levelGenerator
{
    public class DrunkardSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _worldGrid;
        [SerializeField] private GameObject _drunkardManager;
        [SerializeField] private GameObject _drunkard;

        public void StartDrunkard()
        {
            int width;
            int height;
            
            height = _worldGrid.GetComponent<WorldGrid>().Height;
            width = _worldGrid.GetComponent<WorldGrid>().Width;
            
            Instantiate(_drunkard, _drunkardManager.transform);

            _drunkard.transform.position = new Vector3(Mathf.FloorToInt(width/2), Mathf.FloorToInt(height/2),0);
        }
    }
}


