using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject _endingCutscene, _3dPlayer, _respawnPosition;

    private bool hasPressedKey, hasEnterTrigger;
    
    private void Update() 
    {
        if(hasEnterTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPressedKey = true;
            }
        }
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player" && GameManager.Instance.HasKey)
        {
            hasEnterTrigger = true;
            if (hasPressedKey)
            {
                hasPressedKey = false;
                GameManager.Instance.PlayerCanControl = false;
                _3dPlayer.SetActive(false);
                _endingCutscene.SetActive(true);
                Cursor.visible = true;
                _3dPlayer.transform.position = _respawnPosition.transform.position;
                _3dPlayer.transform.rotation = _respawnPosition.transform.rotation;
                GameManager.Instance.ResetGame(); //reset all bool from GameManager                
            }
        }    
    }
}
