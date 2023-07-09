using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    float speed = 3f;

    bool hitting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(   Input.GetKeyDown(KeyCode.F))
        {
            hitting = true;
        }else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false;
        }

        if (hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * 2 * Time.deltaTime);
        }

        if ((h != 0 || v != 0) && !hitting)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime );
        }
    }
}