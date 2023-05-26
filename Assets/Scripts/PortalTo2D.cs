using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTo2D : MonoBehaviour
{
    private bool cutsceneHasPlayed, hasPressedKey, hasEnterTrigger;
    [SerializeField]
    private GameObject goToBedCutscene, player2D, respawnPosition2D;

    private void FixedUpdate()
    {
        if (hasEnterTrigger) //detect pressing key when enter trigger
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPressedKey = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            hasEnterTrigger = true;
            if (hasPressedKey)
            {
                GameManager.Instance.PlayerCanControl = false; //disable player control
                if (!cutsceneHasPlayed)
                {
                    goToBedCutscene.SetActive(true);
                    cutsceneHasPlayed = true;
                }
                UIManager.Instance.WhiteOut();
                player2D.transform.position = respawnPosition2D.transform.position; //reposition 2D player to start point
                GameManager.Instance.Player2DCanControl = true;
                Invoke("Switching", 5f); //switch to 2D scene after 3 seconds- UIManager
                hasEnterTrigger = false;
                hasPressedKey = false;
            }           
        }   
    }

    void Switching()
    {
        Camera.main.orthographic = true;
        UIManager.Instance.SwitchTo2D();
        UIManager.Instance.WhiteIn();
        goToBedCutscene.SetActive(false);
    }
}
