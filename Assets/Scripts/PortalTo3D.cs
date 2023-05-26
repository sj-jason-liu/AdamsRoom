using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTo3D : MonoBehaviour
{
    [SerializeField]
    private int _objectNum;

    [SerializeField]
    private GameObject _player3d, _respawnPosition3d;

    private bool hasPressedKey;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E))
            hasPressedKey = true;
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if(hasPressedKey && other.tag == "Player")
        {
            switch (_objectNum)
            {
                case 0: //closet
                    GameManager.Instance.HasCloset = true;
                    break;
                case 1: //game console
                    GameManager.Instance.HasGameConsole = true;
                    break;
                case 2: //key
                    GameManager.Instance.HasKey = true;
                    break;
            }
            GameManager.Instance.Player2DCanControl = false;
            UIManager.Instance.WhiteOut();
            _player3d.transform.position = _respawnPosition3d.transform.position;
            Invoke("Switching", 3f);
            GameManager.Instance.PlayerCanControl = true;
            hasPressedKey = false;
        }    
    }

    void Switching()
    {
        Camera.main.orthographic = false;
        UIManager.Instance.SwitchTo3D();
        UIManager.Instance.WhiteIn();
    }
}
