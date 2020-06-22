using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

namespace levelGenerator
{
    public class WorldGrid : MonoBehaviour
    {

        [SerializeField] 
        private int _width;
        [SerializeField] 
        private int _height;

        private float _tileSize = 1f;

        [SerializeField] private GameObject referenceTile;

        public int Height => _height;
        public int Width => _width;
        
        
        
        public void Start()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    GameObject tile = (GameObject) Instantiate(referenceTile, transform);

                    float posX = i * _tileSize;
                    float posY = j * _tileSize;

                    tile.transform.position = new Vector2(posX, posY);
                }
            }
            this.gameObject.GetComponent<DrunkardSpawner>().StartDrunkard();
        }
    }
}