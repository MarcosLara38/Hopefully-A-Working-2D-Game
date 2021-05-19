﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerData
{
    public string name = "";
    public int AmountOfHearts;
    public int Health;
    public float AttackSpeed;
    public int AttackDamage;
    public Vector2 PlayerPosition;
    public Vector2[] enemies;
    public int[] currentSpawned;
    public bool[] empty;
    public GameObject[] Triggers;
    public string[] slotIndex;
    public Vector2[] ItemsPositions;
    public string[] ItemName;
    public bool[] ISFull;
    public int Score;

    //public Vector2 PlayerPosition 


}
