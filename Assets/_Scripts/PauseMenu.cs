using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public ThirdPersonController thirdPersonController;
    public GameObject playerReference;

    void Start()
    {
        thirdPersonController = GameObject.FindWithTag("Player")?.GetComponent<ThirdPersonController>();
        //if (thirdPersonController == null)
        //{
        //    Debug.LogError("ThirdPersonController not found or not tagged as 'Player'");
        //}
    }


    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }   
        }
}

   

   public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        thirdPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        thirdPersonController.enabled = true;
        thirdPersonController.GetComponent<Animator>().enabled = true;
    }

   public void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        thirdPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        thirdPersonController.enabled = false;
        thirdPersonController.GetComponent<Animator>().enabled = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
