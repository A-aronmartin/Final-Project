using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public GameController gameController;
    public float tileSizeZ;

    public Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }


    public void Update()
    { 

        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
            transform.position = startPosition + Vector3.forward * newPosition;
        }
    

        if (gameController.score >= 100)
        {
            scrollSpeed = -2; 
        }
    }
}




