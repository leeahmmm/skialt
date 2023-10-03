using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
	// track_count = 3
	[SerializeField] private float track_delta;

	[SerializeField] private GameObject[] post_variants;
	[SerializeField] private float post_move_speed;
  [SerializeField] private float post_spawn_interval;
	private int current_post_variant;
  private float post_spawn_t;
	private List<GameObject> posts;
	private Transform post_parent;

	[SerializeField] private GameObject[] tree_variants;
	[SerializeField] private float tree_move_speed;
  [SerializeField] private float tree_spawn_interval;
	[SerializeField] private float tree_track_padding;
	[SerializeField] private float tree_spawn_width;
  private float tree_spawn_t;
	private List<GameObject> trees;
	private Transform tree_parent;

	void
	Start()
	{
		current_post_variant = 0;
		post_spawn_t         = 0;
		posts                = new List<GameObject>();
		post_parent          = this.transform.Find("Posts");

		tree_spawn_t = 0;
		trees        = new List<GameObject>();
		tree_parent  = this.transform.Find("Trees");
	}

	void
	Update()
	{
    post_spawn_t += Time.deltaTime;

    if (post_spawn_t >= post_spawn_interval)
    {
      GameObject obj = Instantiate(post_variants[current_post_variant], new Vector3(track_delta*Random.Range(-1, 2), 0.7f, 100), Quaternion.identity);
      obj.transform.SetParent(post_parent);
			posts.Add(obj);

      post_spawn_t = 0;
      current_post_variant = (current_post_variant + 1) % post_variants.Length;
    }

		tree_spawn_t += Time.deltaTime;

    if (tree_spawn_t >= tree_spawn_interval)
    {
			float tree_x = (2*Random.Range(0, 2)-1)*(track_delta + tree_track_padding + Random.Range(0.0f, tree_spawn_width));
      GameObject obj = Instantiate(tree_variants[Random.Range(0, tree_variants.Length)], new Vector3(tree_x, 1.9f, 100), Quaternion.Euler(80, 180, 0));
      obj.transform.SetParent(tree_parent);
      trees.Add(obj);

      tree_spawn_t = 0;
    }
	}

	void
	FixedUpdate()
	{
		for (int i = posts.Count-1; i >= 0; --i)
		{
			if (posts[i].gameObject == null) posts.RemoveAt(i);
			else
			{
				posts[i].transform.position = posts[i].transform.position + Vector3.back*post_move_speed*Time.fixedDeltaTime;

				if (posts[i].transform.position.z < -10)
				{
					Destroy(posts[i].gameObject);
					posts.RemoveAt(i);
				}
			}
		}

    for (int i = trees.Count-1; i >= 0; --i)
    {
      trees[i].transform.position = trees[i].transform.position + Vector3.back*tree_move_speed*Time.fixedDeltaTime;
      if (trees[i].transform.position.z <= -10)
      {
        Destroy(trees[i]);
        trees.RemoveAt(i);
      }
    }
	}

	public float
	GetTrackDelta()
	{
		return track_delta;
	}
}
