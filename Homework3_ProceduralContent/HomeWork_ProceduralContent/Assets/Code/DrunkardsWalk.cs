using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace levelGenerator
{
    public class DrunkardsWalk : MonoBehaviour
    {

        [SerializeField] private float _interval;
        [SerializeField] private GameObject _floorTile;

        private int _direction;

        [SerializeField] private int _randomSeed;
        [SerializeField] private bool isSeedRandom;

        private GameObject _worldGrid;
        private WorldGrid _worldGridScript;

        private float _floorPercent;
        [SerializeField] private float _aimedFloorpercent;

        private int _tileCount;
        private int currentFloorCount;

        private GameObject WallLayer;
        private GameObject FloorLayer;

        private void Start()
        {
            _worldGrid = GameObject.Find("WorldGrid");
            _worldGridScript = _worldGrid.GetComponent<WorldGrid>();
            _tileCount = _worldGridScript.Height * _worldGridScript.Width;

            WallLayer = _worldGrid.GetComponent<WorldGrid>().WallLayer;
            FloorLayer = _worldGrid.GetComponent<WorldGrid>().FloorLayer;

            StartCoroutine("DrunkardsWalkStep");

            if (isSeedRandom == false)
            {
                Random.InitState(_randomSeed);
            }
        }

        private IEnumerator DrunkardsWalkStep()
        {
            while (_aimedFloorpercent >= _floorPercent)
            {
                yield return new WaitForSeconds(_interval);

                _direction = Random.Range(1, 5);

                Vector2 currentPosition;
                currentPosition = this.transform.position;


                if (_direction == 1)
                {
                    if (currentPosition.x > 0)
                    {
                        this.gameObject.transform.position = new Vector2(currentPosition.x - 1, currentPosition.y);
                    }
                }

                if (_direction == 2)
                {
                    if (currentPosition.x < _worldGridScript.Width -1)
                    {
                        this.gameObject.transform.position = new Vector2(currentPosition.x + 1, currentPosition.y);
                    }
                }

                if (_direction == 3)
                {
                    if (currentPosition.y > 0)
                    {
                        this.gameObject.transform.position = new Vector2(currentPosition.x, currentPosition.y - 1);
                    }
                }

                if (_direction == 4)
                {
                    if (currentPosition.y < _worldGridScript.Height -1) 
                        this.gameObject.transform.position = new Vector2(currentPosition.x, currentPosition.y + 1);
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.transform.parent == WallLayer.transform)
            {
                Instantiate(_floorTile, FloorLayer.transform);
                _floorTile.transform.position = other.transform.position;

                Destroy(other.gameObject);
            }
        }
        private void Update()
        {
            currentFloorCount = _worldGridScript.FloorLayer.transform.childCount;

            _floorPercent = ((float) currentFloorCount / (float) _tileCount) * 100;
        }
    }
}

