using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
 
{
     
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }


}