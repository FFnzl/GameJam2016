using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BackgroundBehaviour : MonoBehaviour {

    private Color[] colors = { Color.magenta, Color.yellow, Color.cyan };
    private Camera cam;
    public float duration;
    private int colorInc;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        cam.DOColor(colors[colorInc], duration).OnComplete(() =>
            cam.DOColor(Color.black, duration).OnComplete(() => colorInc++));
        colorInc = colorInc % colors.Length;
    }
	
	// Update is called once per frame
	void Update () {

        }
    private void changeColor()
    {

    }
}
