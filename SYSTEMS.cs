using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYSTEMS : MonoBehaviour
{
    void Awake()
    {
        // Ensure that this GameObject persists between scenes
        DontDestroyOnLoad(gameObject);
    }
}
