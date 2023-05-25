using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject _endingCutscene, _3dPlayer;
    
    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player" && GameManager.Instance.HasKey)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.PlayerCanControl = false;
                _3dPlayer.SetActive(false);
                _endingCutscene.SetActive(true);
                Invoke("EndingScene", 5f);
            }
        }    
    }

    void EndingScene()
    {
        //jump to next scene
    }
}
