using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    [SerializeField] private bool isEnemy;
    [SerializeField] private Color _color;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isEnemy)
            {
                GetComponent<SpriteRenderer>().color = new Color(_color.r, _color.g, _color.b, 0.6f);
                GetComponent<SpriteRenderer>().sprite = GameManager.Instance.Kliaksa;
                ParticleSystem particles = Instantiate(Saw.Instance.enemyCollision);
                particles.transform.position = transform.position;
                particles.startColor = new Color(_color.r, _color.g, _color.b, 1f);
                particles.Play();
            
                Destroy(GetComponent<BoxCollider2D>());

                GameManager.Instance.enemyList.Remove(gameObject);
                if (GameManager.Instance.enemyList.Count <= 0)
                {
                    GameManager.Instance.Win();
                }
                
                Destroy(particles.gameObject, 1f);
            }
            else
            {
                print("Lose");
            }
        }
    }
}
