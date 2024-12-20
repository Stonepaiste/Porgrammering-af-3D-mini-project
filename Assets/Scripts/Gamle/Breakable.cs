using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private float _breakForce = 2f;
    [SerializeField] private float _collisionMultiplier = 100f;
    [SerializeField] private bool _broken;

    private void OnCollisionEnter(Collision collison)
    {
        if (_broken) return;
        if (collison.relativeVelocity.magnitude >=_breakForce)
        {
            _broken = true;
            var replacement = Instantiate(_replacement, transform.position, transform.rotation);
            
            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.AddExplosionForce(collison.relativeVelocity.magnitude * _collisionMultiplier,
                    collison.contacts[0].point, 2);
            }
            Destroy(gameObject);
        }
    }
}
