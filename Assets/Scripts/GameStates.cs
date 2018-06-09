using System.Collections.Generic;
using UnityEngine;

public static class GameStates {

    private static Dictionary<string, bool> _gameStates;

    static GameStates()
    {
        _gameStates = new Dictionary<string, bool>();
    }

    public static void Register(string stateName, bool state = false)
    {
        if (_gameStates.ContainsKey(stateName))
        {
            Debug.LogWarning(stateName + " already exists as a GameState. Overwriting it with value " + state);
            _gameStates["stateName"] = state;
        }
        else
        {
            Debug.Log("Adding " + stateName + " to GameStates with value " + state);
            _gameStates.Add(stateName, state);
        }
    }

    public static bool ContainsState(string stateName)
    {
        return _gameStates.ContainsKey(stateName);
    }

    public static bool GetState(string stateName)
    {
        return _gameStates[stateName];
    }

    public static void ToggleState(string stateName)
    {
        if (_gameStates.ContainsKey(stateName))
        {
            Debug.Log("GameState " + stateName + " toggled to " + !_gameStates[stateName]);
            _gameStates[stateName] = !_gameStates[stateName];
        }
        else
        {
            Debug.LogWarning("GameStates does not containe a state with the name " + stateName);
        }
    }

    public static void SetState(string stateName, bool state)
    {
        if (_gameStates.ContainsKey(stateName))
        {
            Debug.Log("GameState " + stateName + " changed to " + state);
            _gameStates[stateName] = state;
        }
        else
        {
            Debug.LogWarning("GameStates does not containe a state with the name " + stateName);
        }
    }
}
