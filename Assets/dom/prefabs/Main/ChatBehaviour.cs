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
        "Tutorial"
    };

    private string[] annoyedPool =
    {
        "annoyed"
    };

    private string[] happyPool =
    {
        "happy"
    };


    // Use this for initialization
    void Start () {
        rt = GetComponent<RectTransform>();
        txt = GetComponentInChildren<Text>();
        yPos = rt.rect.y;
        tweening = false;
        popUp(0);
	}

    /// <summary>
    /// Int parameter determines the choosen Textpool
    /// 0 - Tutorial
    /// 1 - Annoyed
    /// 2 - Happy
    /// </summary>
    void popUp(int mood)
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
            }
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(0, -yPos * 2, 0), 1));
            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(0, yPos * 2, 0), 1).SetDelay(3));

            tweening = false;
        }

    }

}
