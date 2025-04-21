using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject Esc, start;
    public UnityEvent Gamepaused, GameResume, spawnSong;
    [SerializeField] AudioSource door;
    AudioSource click;
    [SerializeField] AudioClip Clik;
    void Awake()
    {
        freez();
    }
    private void Start()
    {
        click = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc.SetActive(true);
            freez();
        }
    }
    public void Clickme()
    {
        click.PlayOneShot(Clik);
    }
    void freez()
    {
        Time.timeScale = 0;
        Gamepaused.Invoke();
    }
    public void unfreez()
    {
        Time.timeScale = 1;
        GameResume.Invoke();
    }
    public void startGame()
    {
        start.SetActive(false);
        unfreez();
        door.Play();
        spawnSong.Invoke();
    }

    public void quit()
    {
        click.PlayOneShot(Clik);
        Application.Quit(); Debug.Log("done");
    }
    public void play()
    {
        Esc.SetActive(false);
        unfreez();
    }
}
