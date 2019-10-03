using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endGameUI;
    GameObject cam;
    JY_Move player;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player").GetComponent<JY_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    public void Toggle() 
    {
        endGameUI.SetActive(!endGameUI.activeSelf);
        if(endGameUI.activeSelf) 
        {
            player.CanMove = false;    
        } else 
        {
            player.CanMove = true;
        }
    }

    public void endGame() {
        cam.GetComponent<AudioSource>().Stop();
        endGameUI.SetActive(true);
        player.CanMove = false;
    }
    public void restartGame() {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
