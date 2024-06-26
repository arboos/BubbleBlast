using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Sprite Kliaksa;

    public List<GameObject> enemyList;
    public Animator Cell;

    public AudioSource bubbleSound;
    public AudioSource winSound;
    

    public GameObject winMask;
    public GameObject pauseMask;
    
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
    }

    public void Win()
    {
        Saw.Instance.gameObject.SetActive(false);
        Cell.SetTrigger("Win");
        winSound.Play();

        StartCoroutine(WinIen());
    }

    public IEnumerator WinIen()
    {
        yield return new WaitForSeconds(2f);

        winMask.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex > YandexGame.savesData.levelsReached)
        {
            YandexGame.savesData.levelsReached = SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMask.SetActive(true);
    }
    
    public void UnPause()
    {
        Time.timeScale = 1;
        pauseMask.SetActive(false);
    }
}
