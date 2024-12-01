using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public GameObject prefab_player;
    public static GameObject s_prefab_player;
    public static Flag[] flags;
    public static int Laps;
    public static int bestScore;
    void Start()
    {
        flags = GetComponentsInChildren<Flag>();

        Laps = 0;

        bestScore = PlayerPrefs.GetInt("BestScore");

        s_prefab_player = prefab_player;

        RespawnPlayer();
    }

    public static void FlagCaptured(int flag)
    {
        if(flag == 0)
        {
            flags[1].isCaptured = false;
        }
        else flags[0].isCaptured = false;

        Laps ++;
    }
    public static void RespawnPlayer()
    {
        Laps = 0;

        if(flags[0].isCaptured)
        {
            Instantiate(s_prefab_player,flags[0].transform.position,Quaternion.identity);
        }
        else
        {
            Instantiate(s_prefab_player,flags[1].transform.position,Quaternion.identity);
        }
    }
}
