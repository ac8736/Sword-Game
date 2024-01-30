using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneShield : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(collision.gameObject);
        }
    }
}
