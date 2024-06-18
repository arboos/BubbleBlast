using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print(1);
            GetComponent<SpriteRenderer>().color = new Color(1,1,1, 0.3f);
        }
    }
}
