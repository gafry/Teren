using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private static Settings s_Instance;

    [Header("World options")]
    public bool loadWorld = false;

    public static Settings Instance
    {
        get
        {
            if (s_Instance != null)
                return s_Instance;

            s_Instance = GameObject.FindObjectOfType<Settings>();
            return s_Instance;
        }
    }
}