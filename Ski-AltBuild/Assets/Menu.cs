using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Menu : MonoBehaviour

{
    public AudioSource OnStart;
    public AudioSource audio;
    private float audioVolume;
    private float timescale;
    private float FadeOut;
    private float FadeIn;
    public GameObject canvas;
    public float FadeOutTime;


  
    void Start()
    {

        // dont destroy ambience or canvas
        AudioSource.DontDestroyOnLoad(this.audio);
        GameObject.DontDestroyOnLoad(canvas);

        FadeIn = 1;

    }
    public void OnPlayButton()
    {
        
        StartCoroutine(DelaySceneLoad());
        OnStart.Play();
        DontDestroyOnLoad(this.OnStart);
        FadeOut += 1;

        
        Debug.Log(FadeOut);
        

    }


    void Update()
    {
        if (FadeOut == 1)
        {
            audio.volume -= Time.deltaTime / FadeOutTime;
        }

    }

    IEnumerator DelaySceneLoad()

    {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);

    }

}
        
  
