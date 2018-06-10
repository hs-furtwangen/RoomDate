using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DialogEntry
{
    public string id;
    public int player;
    public string[] stateDependency;
    public bool used;
    public string[] nextIds;
    public string text;
    public int needsInterest;
    public int interestValue;
}
