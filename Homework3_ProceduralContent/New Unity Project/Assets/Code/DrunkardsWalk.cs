using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class DrunkardsWalk : MonoBehaviour
{
    
    [SerializeField] private float _interval;
    [SerializeField] private int _drunkSteps;

    private int Direction;
    
    private void Awake()
    {
        StartCoroutine((IEnumerator) DrunkardsWalkStep());
    }

    IEnumerable DrunkardsWalkStep()
    {
         Direction = Random.Range(1,4);
        
        // Debug.Log(1);}
        
        // if (_drunkSteps != 0)
        // {
        //     Direction = Random.Range(1,5);
        //     Vector2 currentPosition;
        //     currentPosition = this.transform.position;
        //
        //     if (Direction == 1)
        //     {
        //         this.gameObject.transform.position = new Vector2(currentPosition.x-1, currentPosition.y);
        //     }
        //     if (Direction == 2)
        //     {
        //         this.gameObject.transform.position = new Vector2(currentPosition.x+1, currentPosition.y);
        //     }
        //     if (Direction == 3)
        //     {
        //         this.gameObject.transform.position = new Vector2(currentPosition.x, currentPosition.y-1);
        //     }
        //     if (Direction == 4)
        //     {
        //         this.gameObject.transform.position = new Vector2(currentPosition.x, currentPosition.y+1);
        //     }
        //     this.gameObject.transform.position = new Vector2();
        // }

        // _drunkSteps--;
        
        yield return new WaitForSeconds(_interval);
    }
}
