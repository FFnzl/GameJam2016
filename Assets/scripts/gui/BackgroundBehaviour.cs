using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BackgroundBehaviour : MonoBehaviour {

    private Color[] colors = { new Color(0.7f, 0, 0.7f), new Color(0, 0, 0.7f),
                               new Color(0, 0.7f, 0.7f), new Color(0, 0.7f, 0),
                               new Color(0.7f, 0.7f, 0), new Color(0.7f, 0, 0)};
    private Camera cam;
    public float duration;
    private int colorInc;
    private bool tweening = false;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();    
    }
	
	// Update is called once per frame
	void Update () {
        if (!tweening) changeColor();
    }

    private void changeColor()
    {
        tweening = true;
        DOTween.To(() => cam.backgroundColor, x => cam.backgroundColor = x, colors[colorInc], duration).OnComplete(() => tweening = false);
        colorInc = ++colorInc % colors.Length;
    }
}
