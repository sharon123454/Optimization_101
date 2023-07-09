using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float timerMultiplyer = 1f;

    [SerializeField] private float _timer, _timeTillNextTick = 5f;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _timer -= Time.deltaTime * timerMultiplyer;

        if (_timer < 0)
        {
            KickTheBaby();
            _timer = Random.Range(0, _timeTillNextTick);
        }
    }

    private void KickTheBaby()
    {
        float x = Random.Range(0, 10f);
        float y = Random.Range(0, 10f);
        float z = Random.Range(0, 10f);
        _rigidBody.AddForce(new Vector3(x, y, z), ForceMode.VelocityChange);
    }

}