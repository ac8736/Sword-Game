using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 0.5f;

    public int hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("TargetWall").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime), Quaternion.AngleAxis(angle, Vector3.forward));
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("TargetWall"))
        {
            hp = 0;
        }
    }
}
