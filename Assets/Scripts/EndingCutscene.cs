using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject _endingCutscene, _3dPlayer;

    private bool hasPressedKey;
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E))
            hasPressedKey = true;
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if(hasPressedKey && other.tag == "Player" && GameManager.Instance.HasKey)
        {
            GameManager.Instance.PlayerCanControl = false;
            _3dPlayer.SetActive(false);
            _endingCutscene.SetActive(true);
            Cursor.visible = true;
            GameManager.Instance.ResetGame(); //reset all bool from GameManager
            //BroadcastMessage("ResetPlatform"); //reset moving platform to start position
            hasPressedKey = false;
        }    
    }
}
