using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource buttonClick;

    public void buttonPress()
    {
        buttonClick.Play();
    }
}
