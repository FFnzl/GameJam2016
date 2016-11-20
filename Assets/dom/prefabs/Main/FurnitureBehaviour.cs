using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class FurnitureBehaviour : MonoBehaviour {
    private GameObject uiText;
    private UITimeBehaviour uiScript;

    [SerializeField] private int score;
    [SerializeField] private float weight;

    [SerializeField] private GameObject scoreTextPrefab;

	[SerializeField]
	private int _rubbleSpawnAmount = 6;
    private GameObject scoreText;

    private Room r;
    public Room ParentRoom
    {
        get { return r; }
        set { r = value; }
    }

    private bool collided;
    public bool Collided
    {
        get { return collided; }
        set { collided = value; }
    }

	// Use this for initialization
	void Start () {
        Collided = false;
		uiText = GameObject.FindGameObjectWithTag("uiTimer");
		uiScript = uiText.GetComponent<UITimeBehaviour>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.rigidbody.velocity.magnitude >= weight && Collided == false)
        {
			
			//TODO Add stuff here
			GameObject.Instantiate(Resources.Load("prefabs/pfb_particles_destroy"), transform.position, Quaternion.identity);

            scoreText = Instantiate(scoreTextPrefab, transform.position, Quaternion.identity) as GameObject;
            scoreText.GetComponent<TextMesh>().text = "-" + score.ToString() + " Sec";
            scoreText.transform.DOBlendableMoveBy(Vector2.up, 4).OnComplete<Tween>(() => Object.DestroyObject(scoreText));
            uiScript.addPunish(score);
            Collided = true;

            string trigger = Random.Range(0, 2) >= 1 ? "Angry" : "Shocked"; 

            GameObject.FindGameObjectWithTag("Granny").GetComponent<Animator>().SetTrigger(trigger);

            r.StuffSmashed();

			//TODO Add rubble to room dust list
			for (int i = 0; i < _rubbleSpawnAmount; ++i) {
				GameObject go = GameObject.Instantiate(Resources.Load("prefabs/pfb_rubble"), transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 359.0f)), transform.parent) as GameObject;
				go.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * Random.Range(30.0f, 100.0f);
				r.dust.Add(go);
			}

			GameObject.Instantiate(Resources.Load("prefabs/pfb_destruction_sound"), transform.position, Quaternion.identity);

			Destroy(gameObject);
        }
    }
}
