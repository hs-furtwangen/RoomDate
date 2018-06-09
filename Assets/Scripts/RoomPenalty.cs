using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPenalty : MonoBehaviour {

    public float TimeBonus;

    private RoomTimer _roomTimer;

    // Use this for initialization
    void Start()
    {
        _roomTimer = GameObject.Find("RoomController").GetComponent<RoomTimer>();
    }

    private void OnMouseDown()
    {
        if (TimeBonus != 0 && _roomTimer != null)
        {
            _roomTimer.ModTimer(TimeBonus);
        }
    }
}
