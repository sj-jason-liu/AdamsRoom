using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is NULL!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        PlayerCanControl = false;
        Player2DCanControl = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public bool HasCloset { get; set; }
    public bool HasGameConsole { get; set; }
    public bool HasKey { get; set; }

    public bool PlayerCanControl { get; set;}
    public bool Player2DCanControl { get; set; }

    //Key checking function
        //if object 3 has been collect
        //room door cutscene can be activate by enter trigger
}
