using UnityEngine;
using System.Collections;
using DG.Tweening;

public class logoBehaviour : MonoBehaviour {
    [SerializeField] float duration;

	private RectTransform rt;
    private Vector3 startScale;
    private bool tweening;

	// Use this for initialization
	void Start () {
        rt = GetComponent<RectTransform>();
        startScale = rt.localScale;
        //tweening = false;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(rt.DOBlendableScaleBy(new Vector3(0.3f, 0.3f, 0), duration));
        mySequence.Append(rt.DOBlendableScaleBy(new Vector3(-0.3f, -0.3f, 0), duration));
        mySequence.SetLoops(-1);

        Sequence mySequence1 = DOTween.Sequence();
        mySequence1.Append(rt.DOBlendableRotateBy(new Vector3(0.0f, 0.0f, 10.0f), duration * 2.6f));
        mySequence1.Append(rt.DOBlendableRotateBy(new Vector3(0.0f, 0.0f, -20.0f), duration * 5.2f));
        mySequence1.Append(rt.DOBlendableRotateBy(new Vector3(0.0f, 0.0f, 10.0f), duration * 2.6f));
        mySequence1.SetLoops(-1);

        //mySequence.Append(rt.DOScale(startScale, duration * 4));
        //mySequence.Join(rt.DOBlendableMoveBy(new Vector3(-100, -100, 0), duration));
        //mySequence.Append(rt.DOBlendableMoveBy(new Vector3(100, 100, 0), duration));
        //mySequence.Append(rt.DOBlendableMoveBy(new Vector3(100, -100, 0), duration));
        //mySequence.Append(rt.DOBlendableMoveBy(new Vector3(-100, 100, 0), duration));
        //mySequence.SetLoops(100);
    }
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void move()
    {
        if(!tweening)
        {
            tweening = true;

            /*
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(rt.DOBlendableScaleBy(new Vector3(0.5f, 0.5f, 0), duration));
            mySequence.Append(rt.DOScale(startScale, duration * 4));

            mySequence.Join(rt.DOBlendableMoveBy(new Vector3(-100, -100, 0), duration));
            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(100, 100, 0), duration));
            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(100, -100, 0), duration);
            mySequence.Append(rt.DOBlendableMoveBy(new Vector3(-100, 100, 0), duration);
            */
        }
    }
}
