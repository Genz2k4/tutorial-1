using UnityEngine;
using UnityEngine.SceneManagement;

public class game_ui : MonoBehaviour
{
    public game_manager game_manager;
    
    public void start_game()
    {
        game_manager.StartGame();
    }
    
    public void pause_game()
    {
        game_manager.PauseGame();
    }

    public void resume_game()
    {
        game_manager.ResumeGame();
    }
    
    public void game_over()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit_game()
    {
        Application.Quit();
    }
    
}
