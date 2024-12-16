using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private AudioSource _collectAudioSource;

    private int _coinCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            PlayAudioSource();
            var price = coin.Price;
            coin.Collect();
            _coinCount += price;
        }
    }

    private void PlayAudioSource()
    {
        _collectAudioSource.Play();
    }
}
