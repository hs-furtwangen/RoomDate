using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTimer : MonoBehaviour {

    public float RoomBaseTimer;
    public string NextScene;

    public bool RunTimer;

    private bool _validtimer;

    private void Start()
    {
        if (RoomBaseTimer > 0 && NextScene != "")
        {
            _validtimer = true;
        }
        else
        {
            _validtimer = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (RunTimer && _validtimer)
        {
            if (RoomBaseTimer <= 0)
            {
                this.gameObject.GetComponent<SceneController>().LoadScene(NextScene);
            }
            else
            {
                RoomBaseTimer -= Time.deltaTime;
            }
        }
	}

    public void ModTimer(float amount)
    {
        RoomBaseTimer += amount;
    }
}
