using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class UITimeBehaviour : MonoBehaviour {

    private Text txt;
    [SerializeField] private float timeLimit;

    private ChatBehaviour chat;

    private Color startColor;
    private int startSize;
    private bool changing;
    Stats stats;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        startColor = txt.color;
        startSize = txt.fontSize;
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
        chat = GameObject.FindGameObjectWithTag("Chat").GetComponent<ChatBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        timeLimit -= Time.deltaTime;
        txt.text = ((int)timeLimit).ToString();
        if(timeLimit <= 20)
        {
            if (timeLimit <= 10) showWarning(0.25f);
            else showWarning(0.5f);
        } else
        {
            txt.color = startColor;
            txt.fontSize = startSize;
        }
        stats.restTime = (int)Mathf.Max(0, timeLimit);

        if(timeLimit < 0)
        {
            SceneManager.LoadScene("EndScene");
        }
        if(timeLimit % 10 <= 1)
        {
            chat.popUp(3);
        }
	}

    public void addPunish(int n)
    {
        timeLimit -= n;
    }

    private void showWarning(float d)
    {
        if (!changing)
        {
            changing = true;
            DOTween.To(() => txt.color, x => txt.color = x, Color.red, d).OnComplete(() =>
                 DOTween.To(() => txt.color, x => txt.color = x, Color.black, d));
            DOTween.To(() => txt.fontSize, x => txt.fontSize = x, startSize * 2, d).OnComplete(() =>
                 DOTween.To(() => txt.fontSize, x => txt.fontSize = x, startSize, d).OnComplete(() => changing = false));
        }
    }
}
