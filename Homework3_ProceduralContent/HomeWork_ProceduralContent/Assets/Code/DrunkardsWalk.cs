using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace levelGenerator
{
    public class DrunkardsWalk : MonoBehaviour
    {

        [SerializeField] private float _interval;
        [SerializeField] private GameObject _floorTile;

        public int _direction;

        private GameObject _worldGrid;
        private WorldGrid _worldGridScript;
        
        private float _floorPercent;
        [SerializeField] private float _AimedFloorpercent;
        
        private int _tileCount;
        private int currentFloorCount;

        private void Start()
        {
            _worldGrid = GameObject.Find("WorldGrid");
            _worldGridScript = _worldGrid.GetComponent<WorldGrid>();
            _tileCount = _worldGridScript.Height * _worldGridScript.Width;
            
            StartCoroutine("DrunkardsWalkStep");
        }

        private IEnumerator DrunkardsWalkStep()
        {
            while (_AimedFloorpercent >= _floorPercent)
            {
                yield return new WaitForSeconds(_interval);

                _direction = Random.Range(1, 5);

                Vector2 currentPosition;
                currentPosition = this.transform.position;

                if (_direction == 1)
                {
                    this.gameObject.transform.position = new Vector2(currentPosition.x - 1, currentPosition.y);
                }

                if (_direction == 2)
                {
                    this.gameObject.transform.position = new Vector2(currentPosition.x + 1, currentPosition.y);
                }

                if (_direction == 3)
                {
                    this.gameObject.transform.position = new Vector2(currentPosition.x, currentPosition.y - 1);
                }

                if (_direction == 4)
                {
                    this.gameObject.transform.position = new Vector2(currentPosition.x, currentPosition.y + 1);
                }
            }
        }
        private void Update()
        {
            currentFloorCount = _worldGridScript.FloorLayer.transform.childCount;
            
            _floorPercent = ((float) currentFloorCount/ (float) _tileCount) * 100 ;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.transform.parent == _worldGrid.GetComponent<WorldGrid>().WallLayer.transform)
            {
                Instantiate(_floorTile, _worldGrid.GetComponent<WorldGrid>().FloorLayer.transform);
                _floorTile.transform.position = other.transform.position;
       
                Destroy(other.gameObject);
            }
        }
    }
}

