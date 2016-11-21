using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class ChatBehaviour : MonoBehaviour {

    public RectTransform _visiblePoint;
    public RectTransform _invisiblePoint;
    private ControllerManager cm;

    private RectTransform rt;
    private AudioSource aus;
    private Text txt;

    private float yPos;

    private bool tweening;

    private string[] tutorialPool =
    {
        "Use E to grab and plug the plug!",
        "Use A to grab and plug the plug!" 
    };

    private string[] annoyedPool =
    {
        "You are a dissapointment!",
        "Would you please not!?",
        "No dinner tonight!",
        "Be more careful!",
        "Why did you do that!?",
        "That escalated quickly...",
		"Well, that sucked..."
    };

    private string[] happyPool =
    {
        "Groovy!",
		"Splendid!",
        "Incredible!",
		"Wow!",
        "Better than I expected!",
        "You got the SWAG!",
        "MO-MO-MO-MO-MONSTERKILL!!!"
    };

    private string[] tipsPool =
    {
        "Sometimes dirt hides under stuff!",
        "Try not to break something!",
        "Eat your vegetables!",
        "My back hurts!",
        "Be careful with your cable!",
        "Keep an eye on the mini map!",
		"Don't forget the plug!"
    };

    void Awake() {
aus = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        rt = GetComponent<RectTransform>();
        txt = GetComponentInChildren<Text>();
        cm = FindObjectOfType<ControllerManager>();
        yPos = -rt.rect.size.y;
        tweening = false;
        popUp(0,0);
        
	}

    /// <summary>
    /// First parameter determines the choosen Textpool
    /// 0 - Tutorial
    /// 1 - Annoyed
    /// 2 - Happy
    /// 3 - Tips
    /// 
    /// Second parameter determines which message you get TUTORIAL ONLY
    /// </summary>
    public void popUp(int mood)
    {
        if (!tweening)
        {
            aus.Play();

            tweening = true;

            switch (mood)
            {
                case 0:
                    txt.text = tutorialPool[Random.Range(0, tutorialPool.Length)];
                    break;
                case 1:
                    txt.text = annoyedPool[Random.Range(0, annoyedPool.Length)];
                    break;
                case 2:
                    txt.text = happyPool[Random.Range(0, happyPool.Length)];
                    break;
                case 3:
                    txt.text = tipsPool[Random.Range(0, tipsPool.Length)];
                    break;
            }
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(rt.DOMove(_visiblePoint.position, 1));
            mySequence.Append(rt.DOMove(_invisiblePoint.position, 1).SetDelay(3));
            mySequence.AppendCallback(() => tweening = false);
        }
    }

    public void popUp(int mood, int index)
    {
        if (!tweening)
        {
            aus.Play();
            tweening = true;

            switch (mood)
            {
                case 0:
                    if (index == 0)
                    {
                        if (cm.UsingController == true) txt.text = tutorialPool[1];
                        else txt.text = tutorialPool[0];
                    }
                    break;
                case 1:
                    txt.text = annoyedPool[Random.Range(0, annoyedPool.Length)];
                    break;
                case 2:
                    txt.text = happyPool[Random.Range(0, happyPool.Length)];
                    break;
                case 3:
                    txt.text = happyPool[Random.Range(0, tipsPool.Length)];
                    break;
            }
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(rt.DOMove(_visiblePoint.position, 1));
            mySequence.Append(rt.DOMove(_invisiblePoint.position, 1).SetDelay(3));
            mySequence.AppendCallback(() => tweening = false);
        }
    }
}
