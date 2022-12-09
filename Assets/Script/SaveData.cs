using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int gold;
    public int deaths;
    public int damagePermanent = 0;
    public int speedPermanent = 0;
    public bool isLocked = true;
    public bool isPlayerUnlocked;
}
