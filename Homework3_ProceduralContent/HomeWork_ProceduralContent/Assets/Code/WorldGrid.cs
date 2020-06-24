using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace levelGenerator
{
    public class WorldGrid : MonoBehaviour
    {
        [SerializeField] private GameObject _floorLayer;
        [SerializeField] private GameObject _wallLayer;
        
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        public GameObject FloorLayer
        {
            get => _floorLayer;
            set => _floorLayer = value;
        }

        public GameObject WallLayer
        {
            get => _wallLayer;
            set => _wallLayer = value;
        }
        
        private float _tileSize = 1f;

        [SerializeField] private GameObject referenceTile;

        public int Height => _height;
        public int Width => _width;
        
        private void Start()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    GameObject tile = (GameObject) Instantiate(referenceTile, _wallLayer.transform);

                    float posX = i * _tileSize;
                    float posY = j * _tileSize;

                    tile.transform.position = new Vector2(posX, posY);
                }
            }
            this.gameObject.GetComponent<DrunkardSpawner>().StartDrunkard();
        }
    }
}