using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Sprite Kliaksa;

    public List<GameObject> enemyList;
    public Animator Cell;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        Time.timeScale = 2f;
    }

    public void Win()
    {
        Saw.Instance.gameObject.SetActive(false);
        Cell.SetTrigger("Win");
    }
}
