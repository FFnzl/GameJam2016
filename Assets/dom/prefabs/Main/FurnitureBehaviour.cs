using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class FurnitureBehaviour : MonoBehaviour {
    [SerializeField] private GameObject uiText;
    private UITimeBehaviour uiScript;

    [SerializeField] private int score;
    [SerializeField] private float weight;

    [SerializeField] private GameObject scoreTextPrefab;
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
        uiScript = uiText.GetComponent<UITimeBehaviour>();
        Collided = false;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.rigidbody.velocity.magnitude >= weight && Collided == false)
        {
            scoreText = Instantiate(scoreTextPrefab, transform.position, Quaternion.identity) as GameObject;
            scoreText.GetComponent<TextMesh>().text = "-" + score.ToString() + " Sec";
            scoreText.transform.DOBlendableMoveBy(Vector2.up, 1).OnComplete<Tween>(() => Object.DestroyObject(scoreText));
            uiScript.addPunish(score);
            Collided = true;

            string trigger = Random.Range(0, 2) >= 1 ? "Angry" : "Shocked"; 

            GameObject.FindGameObjectWithTag("Granny").GetComponent<Animator>().SetTrigger(trigger);

            r.StuffSmashed();
        }
    }
}
