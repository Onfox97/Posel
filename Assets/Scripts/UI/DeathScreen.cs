using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI text_score;
    void Start()
    {
        

        if(FlagManager.bestScore < FlagManager.Laps)
        {
            FlagManager.bestScore = FlagManager.Laps;
            PlayerPrefs.SetInt("BestScore",FlagManager.bestScore);

            text_score.text = "You have delivered " + FlagManager.Laps +" mail \n" + "The best ammount so far...";
        }
        else
        {
            text_score.text = "You have delivered " + FlagManager.Laps +" mail";
        }

    }
    public void Respawn()
    {
        FlagManager.RespawnPlayer();
        Destroy(gameObject);
    }


}
