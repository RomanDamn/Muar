using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _price;

    public int Price => _price;

    public void PlayAudioSource()
    {
        _audioSource.Play();
    }

    public void Collect()
    {
        gameObject.SetActive(false);
    }
}
