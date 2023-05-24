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
    }

    //Go to bed cutscene counter
        //if
        //Go-to-bed Cutscene never been played
        //play Go-to-bed Cutscene

    //Object 1-closet checking bool
    //Object 2-game console checking bool
    //Object 3-key checking bool

    //Object 1 checking function
        //if object 1 has been collect     
        //disable object 1 in 2D
        //enable object 1 in 3D
        //activate the moving platform 1

    //Object 2 checking function
        //if object 2 has been collect       
        //disable object 2 in 2D
        //enable object 2 in 3D
        //activate moving platform 2

    //Key checking function
        //if object 3 has been collect
        //room door cutscene can be activate by enter trigger
}
