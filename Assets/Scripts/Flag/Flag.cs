using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public bool isCaptured;
    public int flagID;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!isCaptured)
        {
            isCaptured = true;
            FlagManager.FlagCaptured(flagID);
        }
    }
}
