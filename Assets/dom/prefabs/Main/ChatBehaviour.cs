using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class ChatBehaviour : MonoBehaviour {

    private RectTransform rt;
    private Text txt;

    private float yPos;

    private bool tweening;

    private string[] tutorialPool =
    {
        "Use E to grab and plug the plug!"
    };

    private string[] annoyedPool =
    {
        "You are a dissapointment!",
        "Would you please not!?",
        "No dinner tonight!",
        "Be more careful!",
        "Why did you do that!?",
        "That escalated quickly..."
    };

    private string[] happyPool =
    {
        "Groovy!",
        "Incredible!",
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
        "Be careful with your cable!"
    };


    // Use this for initialization
    void Start () {
        rt = GetComponent<RectTransform>();
        txt = GetComponentInChildren<Text>();
        yPos = rt.rect.y;
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

            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(0, -yPos * 2, 0), 1));
            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(0, yPos * 2, 0), 1).SetDelay(3));
            mySequence.AppendCallback(() => tweening = false);
        }
    }

    public void popUp(int mood, int index)
    {
        if (!tweening)
        {
            tweening = true;

            switch (mood)
            {
                case 0:
                    txt.text = tutorialPool[index];
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

            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(0, -yPos * 2, 0), 1));
            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(0, yPos * 2, 0), 1).SetDelay(3));
            mySequence.AppendCallback(() => tweening = false);
        }
    }
}
