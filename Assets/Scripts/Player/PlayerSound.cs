using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public PlayerMove2D move;
    public AudioSource audio_shoot;
    public AudioSource audio_step;

    public void Shoot()
    {
        audio_shoot.pitch = Random.Range(0.9f,1.1f);
        audio_shoot.Play();
    }
    public void Step()
    {
        if(move.isPlayerGrounded)
        {
            audio_step.pitch = Random.Range(0.9f,1.1f);
            audio_step.Play(); 
        }
    }
}
