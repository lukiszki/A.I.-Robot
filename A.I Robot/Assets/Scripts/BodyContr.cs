using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyContr : MonoBehaviour
{
    PlayerController controller;

    private void Start()
    {
        controller = transform.parent.gameObject.GetComponent<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            controller.Dead();
        }
    }
}
