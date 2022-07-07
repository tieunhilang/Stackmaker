using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected Transform playObj;
    public enum PlayerFSM
    {
        MoveU,
        MoveD,
        MoveL,
        MoveR,
    }
    public virtual void UpdatePlayer(Transform playerObj)
    {

    }
    protected void DoAction(Transform playerObj, PlayerFSM playerMode)
    {
        float moveSpeed = 20f;
        switch (playerMode)
        {
            case PlayerFSM.MoveU:
                playObj.GetComponent<Rigidbody>().velocity = Vector3.forward * moveSpeed;
                break;
            case PlayerFSM.MoveD:
                playObj.GetComponent<Rigidbody>().velocity = Vector3.back * moveSpeed;
                break;
            case PlayerFSM.MoveL:
                playObj.GetComponent<Rigidbody>().velocity = Vector3.left * moveSpeed;
                break;
            case PlayerFSM.MoveR:
                playObj.GetComponent<Rigidbody>().velocity = Vector3.right * moveSpeed;
                break;

        }
    }
}

