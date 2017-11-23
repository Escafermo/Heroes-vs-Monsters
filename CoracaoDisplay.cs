using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class CoracaoDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAIL};

    public Text coracaoDisplay;
    public int coracao;


	void Start () {
        coracaoDisplay = GetComponent<Text>();
        UpdateDisplay();
    }
	
    public void AddCoracao(int corValue)
    {
        coracao += corValue;
        print(corValue + " coracao added");
        UpdateDisplay();
    }


    public Status UseCoracao (int corValue)
    {
        if (coracao >= corValue)
        {
            coracao -= corValue;
            print(corValue + " coracao removed");
            UpdateDisplay();
            return Status.SUCCESS;
        } 
            return Status.FAIL;       
    }


    public void UpdateDisplay()
    {
        coracaoDisplay.text = coracao.ToString();
    }

}
