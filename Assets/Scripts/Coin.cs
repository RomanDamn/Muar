using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlayAudioSource()
    {
        _audioSource.Play();
    }
}
