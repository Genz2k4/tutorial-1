using UnityEngine;

public class gamemanager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject startMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tiep_tuc()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void thoat()
    {
        Application.Quit();
    }

    public void pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void game_over()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void start_game()
    {
        Time.timeScale = 1;
        startMenu.SetActive(false);
    }

    public void new_game()
    {
        gameOverMenu.SetActive(false);
        startMenu.SetActive(true);
    }
}
