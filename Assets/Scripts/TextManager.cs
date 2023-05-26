using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private static TextManager _instance;
    public static TextManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("TextManager is NULL!");
            return _instance;
        }
    }

    private void Awake() 
    {
        _instance = this;
    }
}
