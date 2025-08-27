using UnityEngine;

[RequireComponent(typeof(Health), typeof(BoxCollider2D))]
public class Collector : MonoBehaviour
{
    [SerializeField] private AudioSource _collectAudioSource;

    private int _coinCount = 0;
    private BoxCollider2D _nonTriggerCollider;

    private void Awake()
    {
        _nonTriggerCollider = GetNonTriggerCollider();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_nonTriggerCollider.IsTouching(collision) == false)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            PlayAudioSource();
            var price = coin.Price;
            coin.Collect();
            _coinCount += price;
        }

        if (collision.gameObject.TryGetComponent(out MedicineKit kit))
        {
            var heroHealth = gameObject.GetComponent<Health>();
            heroHealth.IncreaseHealth(kit.HealStep);

            collision.gameObject.SetActive(false);
        }
    }

    private void PlayAudioSource()
    {
        _collectAudioSource.Play();
    }

    private BoxCollider2D GetNonTriggerCollider()
    {
        BoxCollider2D nonTriggerCollider = null;
        var colliders = GetComponents<BoxCollider2D>();

        foreach (var collider in colliders)
        {
            if (collider.isTrigger == false)
            {
                nonTriggerCollider = collider;
            }
        }

        return nonTriggerCollider;
    }
}
