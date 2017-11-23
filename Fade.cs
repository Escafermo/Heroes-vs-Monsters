using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    public float fadeTime;

    private Image fadePanel;
    public Color currentColor = new Color32(106, 159, 105,255);

	void Start ()
    {
        fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Time.timeSinceLevelLoad < fadeTime)
        {
            float alphaChange = Time.deltaTime / fadeTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;


        } else
        {
            gameObject.SetActive(false);
        }


	}
}
