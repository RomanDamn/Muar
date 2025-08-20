using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineKit : MonoBehaviour
{
    [SerializeField] int _healStep;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hero = collision.gameObject.GetComponent<Hero>();

        if(hero != null && collision.isTrigger == false)
        {
            var heroHealth = collision.gameObject.GetComponent<HealthController>();
            heroHealth.IncreaseHealth(_healStep);

            gameObject.SetActive(false);
        }
    }
}
