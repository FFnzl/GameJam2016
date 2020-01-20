using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class FurnitureBehaviour : MonoBehaviour
{
	private GameObject uiText;
	private UITimeBehaviour uiScript;

	private ChatBehaviour chat;

	[SerializeField] private int score;
	[SerializeField] private float weight;

	[SerializeField] private GameObject scoreTextPrefab;

	[SerializeField]
	private int _rubbleSpawnAmount = 6;
	private GameObject scoreText;

	public Room ParentRoom { get; set; }

	public bool Collided { get; set; }

	// Use this for initialization
	void Start()
	{
		Collided = false;
		uiText = GameObject.FindGameObjectWithTag("uiTimer");
		uiScript = uiText.GetComponent<UITimeBehaviour>();

		chat = GameObject.FindGameObjectWithTag("Chat").GetComponent<ChatBehaviour>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag != "Cable" && collision.rigidbody.velocity.magnitude >= weight && Collided == false)
		{
			chat.PopUp(1);
			//TODO Add stuff here
			GameObject.Instantiate(Resources.Load("prefabs/pfb_particles_destroy"), transform.position, Quaternion.identity);

			scoreText = Instantiate(scoreTextPrefab, transform.position, Quaternion.identity) as GameObject;
			scoreText.GetComponent<TextMesh>().text = "-" + score.ToString() + " Sec";
			scoreText.transform.DOBlendableMoveBy(Vector2.up, 4).OnComplete<Tween>(() => Destroy(scoreText));
			uiScript.AddPunish(score);
			Collided = true;

			string trigger = Random.Range(0, 2) >= 1 ? "Angry" : "Shocked";

			GameObject.FindGameObjectWithTag("Granny").GetComponent<Animator>().SetTrigger(trigger);

			ParentRoom.StuffSmashed();

			//TODO Add rubble to room dust list
			for (int i = 0; i < _rubbleSpawnAmount; ++i)
			{
				GameObject go = GameObject.Instantiate(Resources.Load("prefabs/pfb_rubble"), transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 359.0f)), transform.parent) as GameObject;
				go.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * Random.Range(30.0f, 100.0f);
				ParentRoom.dust.Add(go);
			}

			GameObject.Instantiate(Resources.Load("prefabs/pfb_destruction_sound"), transform.position, Quaternion.identity);

			Destroy(gameObject);
		}
	}
}
