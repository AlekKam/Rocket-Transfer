using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float oscillationSpeed = 0.5f;
    public float oscillationAmplitude = 1f;
    public int damage = 10;

    private Vector3 startPosition;
    private float timeSinceLastOscillation;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        timeSinceLastOscillation += Time.deltaTime;
        float oscillation = Mathf.Sin(timeSinceLastOscillation * oscillationSpeed) * oscillationAmplitude;
        transform.position = startPosition + new Vector3(0, oscillation, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }
}