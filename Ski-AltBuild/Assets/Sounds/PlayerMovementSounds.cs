using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementSounds : MonoBehaviour

{

    // sounds
    [SerializeField]AudioClip[] sounds;
    [SerializeField] AudioClip[] sounds2;
    AudioSource source;
    AudioSource source2;
    private float edgeDetect;

    // Start is called before the first frame update
    void Start()
    {

        source = GetComponent<AudioSource>();
        source2 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // sound
        if (Input.GetButtonDown("MoveLeft") && (edgeDetect != 1))
        {
            Sounds();
            edgeDetect += 1;
        }
        if (Input.GetButtonDown("MoveRight") && (edgeDetect != -1))
        {
            Sounds2();
            edgeDetect += -1;
        }
        
    }
    
    void Sounds()
    {
        AudioClip clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        source.PlayOneShot(clip);
    }

    void Sounds2()
    {
        AudioClip clip = sounds2[UnityEngine.Random.Range(0, sounds.Length)];
        source2.PlayOneShot(clip);
    }
}
