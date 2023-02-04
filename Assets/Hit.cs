using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private GameRTSController rtsController;
    public CircleCollider2D circleCollider;
    public LayerMask layerMask;
    private int damage = 10;
    void OnEnable()
    {
        rtsController = GameObject.FindWithTag("RTScontroller").GetComponent<GameRTSController>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(circleCollider.transform.position, circleCollider.radius, layerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<EnemyHealth>().TakeDamage(damage * rtsController.SelectedRTS);
        }
        gameObject.SetActive(false);

    }
}
