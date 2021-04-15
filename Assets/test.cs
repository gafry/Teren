using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Mathematics;
using System;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector2 vecA = new Vector2(0, 100);
        Vector2 vecB = new Vector2(500, -100);

        float resultA = distanceMy(vecA, vecB);
        float resultB = distanceDefault(vecA, vecB);
        if (!resultA.Equals(resultB))
            Debug.Log("oops");*/
    }

    public float distanceDefault(Vector2 vecA, Vector2 vecB)
    {
        return Vector2.Distance(vecA, vecB);
    }

    public float distanceMy(Vector2 vecA, Vector2 vecB)
    {        
        Vector2 heading;
        heading.x = vecA.x - vecB.x;
        heading.y = vecA.y - vecB.y;
        float distanceSquared = heading.x * heading.x + heading.y * heading.y;
        return Mathf.Sqrt(distanceSquared);
    }

    public uint hash(uint input)
    {
        input ^= 2747636419u;
        input *= 2654435769u;
        input ^= input >> 16;
        input *= 2654435769u;
        input ^= input >> 16;
        input *= 2654435769u;
        return input;
    }
}
