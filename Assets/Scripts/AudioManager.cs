using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip levelMusic;
    private AudioSource _audioSource;
    
    /// <startedBy> Jason </startedBy>
    /// <summary>
    /// Initialises variables, a scene load function and assigns the audio manager to not get destroyed upon loading a
    /// new scene.
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        _audioSource = GetComponent<AudioSource>();
    }
    
    /// <startedBy> Jason </startedBy>
    /// <summary>
    /// Event handler that plays the appropriate music, according to the current scene.
    /// </summary>
    /// <param name="scene">The current scene, as given by SceneManager.sceneLoaded</param>
    /// <param name="mode">Unused, as given by SceneManager.sceneLoaded</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentScene = scene.name;
        switch (currentScene)
        {
            case "MainMenu":
                print("Main menu!");
                PlayMusic(menuMusic);
                break;
            default:
                print("Levels!");
                PlayMusic(levelMusic);
                break;
        }
    }
    
    /// <startedBy> Jason </startedBy>
    /// <summary>
    /// Plays the given music file.
    /// </summary>
    /// <param name="clip">The audio clip to be played.</param>
    private void PlayMusic(AudioClip clip)
    {
        if (_audioSource.clip != clip)  // If the audio file is already playing, don't replay it
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
    
    /// <startedBy> Jason </startedBy>
    /// <summary>
    /// Plays the given sound effect.
    /// </summary>
    /// <param name="clip">The audio clip to be played.</param>
    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip,1f);
    }
}
