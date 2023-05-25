using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is NULL!");
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject _2dScene, _3dScene;

    private Animator animator;

    private void Awake() 
    {
        _instance = this;
        animator = GetComponentInChildren<Animator>();
        if(animator == null)
            Debug.LogError("Animator is NULL!");    
    }

    //Play white-in animation
    public void WhiteIn()
    {
        animator.SetTrigger("WhiteIn");
    }
    //Play white-out animation
    public void WhiteOut()
    {
        animator.SetTrigger("WhiteOut");
    }

    //enable/disable 2D scene
    //enable/disable 3D scene
    public void SwitchTo2D()
    {
        _3dScene.SetActive(false);
        _2dScene.SetActive(true);
    }

    public void SwitchTo3D()
    {
        _2dScene.SetActive(false);
        _3dScene.SetActive(true);
    }
}
