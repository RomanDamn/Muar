using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _platformMask;

    public bool GetIsGrounded(BoxCollider2D collider)
    {
        var angle = 0f;
        var distance = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, angle, Vector2.down, distance, _platformMask);
        return raycastHit.collider != null;
    }
}
