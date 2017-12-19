using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public Color pressedColor = Color.white;
    public Color blackedColor = new Color(1f, 1f, 1f, 0.65f);
    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;

    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogWarning(name + "No cost text!");
        } else
        {
            costText.text = defenderPrefab.GetComponent<Defender>().coracaoCusto.ToString();
        }
    }


    public void OnMouseDown()
    {
 
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = blackedColor;
        }

        GetComponent<SpriteRenderer>().color = pressedColor;

        selectedDefender = defenderPrefab;
        
    }


}
