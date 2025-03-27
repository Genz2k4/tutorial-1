using UnityEngine;

public class audio_manager : MonoBehaviour
{
    [SerializeField] AudioSource audio_source;
    [SerializeField] AudioSource default_audio_source;
    [SerializeField] AudioClip shoot_clip;
    [SerializeField] AudioClip reload_clip;
    [SerializeField] AudioClip energy_clip;
    [SerializeField] AudioClip die_clip;
    [SerializeField] AudioClip win_clip;
    [SerializeField] AudioClip select_clip;
    [SerializeField] AudioClip hit_clip;
    [SerializeField] AudioClip lose_clip;
    [SerializeField] AudioClip score_clip;
    
    public void play_shoot()
    {
        audio_source.PlayOneShot(shoot_clip);
    }
    
    public void play_reload()
    {
        audio_source.PlayOneShot(reload_clip);
    }
    
    public void play_energy()
    {
        audio_source.PlayOneShot(energy_clip);
    }
    
    public void play_die()
    {
        audio_source.PlayOneShot(die_clip);
    }
    
    public void play_win()
    {
        default_audio_source.Stop();
        audio_source.PlayOneShot(win_clip);
    }
    
    public void play_select()
    {
        audio_source.PlayOneShot(select_clip);
    }
    
    public void play_hit()
    {
        audio_source.PlayOneShot(hit_clip);
    }
    
    public void play_lose()
    {
        default_audio_source.Stop();
        audio_source.PlayOneShot(lose_clip);
    }
    
    public void play_score()
    {
        audio_source.PlayOneShot(score_clip);
    }
    
    public void play_default()
    {
        default_audio_source.Play();
    } 
    
    public void stop_all()
    {
        default_audio_source.Stop();
        audio_source.Stop();
    }
}
