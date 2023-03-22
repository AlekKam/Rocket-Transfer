using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public HingeJoint boulderHinge;

    public enum Size { Small, Medium, Large }
    public Size size = Size.Small;

    public int smallBoulderHealthCost = 2;
    public int mediumBoulderHealthCost = 4;
    public int largeBoulderHealthCost = 8;

    private Player player;
    private float timeSinceLastDamage = 0f;
    public float damageInterval = 2f;
    public bool isHeld = false;


    private void Start()
    {
        boulderHinge.connectedBody = null;
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && boulderHinge.connectedBody != null)
        {
            boulderHinge.connectedBody = null;
            isHeld = false;
        }

        if (!isHeld)
        {
            timeSinceLastDamage = 0;
            return;
        }

        timeSinceLastDamage += Time.deltaTime;
        if (timeSinceLastDamage >= damageInterval)
        {
            switch (size)
            {
                case Size.Small:
                    player.TakeDamage(smallBoulderHealthCost);
                    break;
                case Size.Medium:
                    player.TakeDamage(mediumBoulderHealthCost);
                    break;
                case Size.Large:
                    player.TakeDamage(largeBoulderHealthCost);
                    break;
            }
            timeSinceLastDamage = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cable"))
        {
            boulderHinge.connectedBody = collision.rigidbody;
            isHeld = true;
        }
    }
}
