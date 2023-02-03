using System.Collections;
using System.Collections.Generic;
using TopDownShooter;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject player;

    public float speed;

    public float rotationModifier;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerBodyHel");
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

    }

}
