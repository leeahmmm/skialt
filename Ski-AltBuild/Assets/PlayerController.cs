using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private GameObject score_text;
  private GameObject post;
  private int score;
	private float track_delta;

    [SerializeField] AudioClip[] sounds;
    AudioSource source;



    void
  Start()
  {
    post = null;
    score = 0;
    score_text.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: 0";

		track_delta = GameObject.Find("Tracks").GetComponent<TrackManager>().GetTrackDelta();

        source = GetComponent<AudioSource>();
    }

  void
  Update()
  {
        
		float delta = 0;
		if      (Input.GetButtonDown("MoveLeft"))  delta -= 1;
        else if (Input.GetButtonDown("MoveRight")) delta += 1;
        
    float new_x = Mathf.Clamp(this.transform.position.x + delta*track_delta, -track_delta, track_delta);

    this.transform.position = new Vector3(new_x, this.transform.position.y, this.transform.position.z);


        if (Input.GetButtonDown("Jump") && post != null)
    {
      Destroy(post);
      score += 1;
      score_text.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + System.Convert.ToString(score);

            AudioClip clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
            source.PlayOneShot(clip);
    }


    }

  void
  OnTriggerEnter(Collider collider)
  {
    post = collider.gameObject;
   
    }

  void
  OnTriggerExit(Collider collider)
  {
    post = null;
  }
}
