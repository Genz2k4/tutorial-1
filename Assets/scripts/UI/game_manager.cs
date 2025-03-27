using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class game_manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] int score;
    [SerializeField] float max_energy,  current_energy;
    [SerializeField] GameObject main_menu, win_game, pause_game, game_over, boss_is_coming, energy_barr, score_barr, ammor_barr;
    [SerializeField] audio_manager audio_manager;
    [SerializeField] Image energy_bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score_text.text = $"{score}";
        MainMenu();
        audio_manager.stop_all();
        update_energy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void add_score()
    {
        score ++;
        score_text.text = $"{score}";
        audio_manager.play_score();
    } 
    
    public void add_energy()
    {
        current_energy++;
        update_energy();
        audio_manager.play_score();
    }

    public void MainMenu()
    {
        main_menu.SetActive(true);
        win_game.SetActive(false);
        pause_game.SetActive(false);
        game_over.SetActive(false);
        energy_barr.SetActive(false);
        score_barr.SetActive(false);
        ammor_barr.SetActive(false);
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        main_menu.SetActive(false);
        win_game.SetActive(false);
        pause_game.SetActive(true);
        game_over.SetActive(false);
        energy_barr.SetActive(false);
        score_barr.SetActive(false);
        ammor_barr.SetActive(false);
        audio_manager.stop_all();
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        main_menu.SetActive(false);
        win_game.SetActive(false);
        pause_game.SetActive(false);
        boss_is_coming.SetActive(false);
        energy_barr.SetActive(false);
        score_barr.SetActive(false);
        ammor_barr.SetActive(false);
        game_over.SetActive(true);
        audio_manager.play_lose();
        Time.timeScale = 0;
    }
    
    public void WinGame()
    {
        main_menu.SetActive(false);
        win_game.SetActive(true);
        pause_game.SetActive(false);
        game_over.SetActive(false);
        boss_is_coming.SetActive(false);
        energy_barr.SetActive(false);
        score_barr.SetActive(false);
        ammor_barr.SetActive(false);
        audio_manager.play_win();
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        main_menu.SetActive(false);
        win_game.SetActive(false);
        pause_game.SetActive(false);
        game_over.SetActive(false);
        energy_barr.SetActive(true);
        score_barr.SetActive(true);
        ammor_barr.SetActive(true);
        audio_manager.play_default();
        Time.timeScale = 1;
    }
    
    public void ResumeGame()
    {
        main_menu.SetActive(false);
        win_game.SetActive(false);
        pause_game.SetActive(false);
        game_over.SetActive(false);
        energy_barr.SetActive(true);
        score_barr.SetActive(true);
        ammor_barr.SetActive(true);
        audio_manager.play_default();
        Time.timeScale = 1;
    }

    public void boss_coming()
    {
        boss_is_coming.SetActive(true);
    }

    public void update_energy()
    {
        current_energy = Mathf.Max(0, current_energy);
        energy_bar.fillAmount = current_energy /  max_energy;
    }
}
