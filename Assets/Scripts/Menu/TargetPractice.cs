using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public GameObject[] targets = new GameObject[3];
    int currentTargert;
    public void Hit()
    {
        targets[currentTargert].SetActive(false);
        currentTargert ++;
        if( currentTargert == 3) currentTargert = 0;
        targets[currentTargert].SetActive(true);
    }
}
