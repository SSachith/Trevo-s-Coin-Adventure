using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausemenu : MonoBehaviour {

    public static bool GameIsPaused=false;
    public GameObject PauseMenuUI;
	// Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
	public void resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    
    }
    public void MainManu() {
        
        SceneManager.LoadScene("StartMenu");
        
    }

    public void QuitGame()
    {
        Application.Quit();
       
    }
    
    public void restartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        // dont add restart button to game xD ;)
    }
}
