using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerSprite;
    public float followSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        PlayerSprite.transform.position = (Vector3.MoveTowards(PlayerSprite.transform.position, Player.transform.position, followSpeed));
       
    }
}
