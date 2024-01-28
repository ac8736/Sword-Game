using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_swing : MonoBehaviour
{
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            ani.SetTrigger("swing");
        }
        
    }
}
