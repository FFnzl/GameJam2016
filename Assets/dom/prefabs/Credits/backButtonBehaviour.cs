using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backButtonBehaviour : MonoBehaviour {
    private Color[] colors = { new Color(0.7f, 0, 0.7f), new Color(0, 0, 0.7f),
                               new Color(0, 0.7f, 0.7f), new Color(0, 0.7f, 0),
                               new Color(0.7f, 0.7f, 0), new Color(0.7f, 0, 0)};
    private Image img;
    [SerializeField]
    private float duration;
    private int colorInc;
    private bool tweening = false;

    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tweening) changeColor();
    }

    private void changeColor()
    {
        tweening = true;
        DOTween.To(() => img.color, x => img.color = x, colors[colorInc], duration).OnComplete(() => tweening = false);
        colorInc = ++colorInc % colors.Length;
    }

    public void goBack()
    {
        SceneManager.LoadScene("mainScene");
    }
}
