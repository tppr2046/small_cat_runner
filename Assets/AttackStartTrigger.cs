using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class AttackStartTrigger : MonoBehaviour
{
    public string EventName;

    void AttackStart()
    {

        foreach (PlayMakerFSM _fsm in this.GetComponents<PlayMakerFSM>())
        {
            _fsm.SendEvent(EventName);
        }

    }
}
