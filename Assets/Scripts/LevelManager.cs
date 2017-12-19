using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    private string lastLevel;

    void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled, use a positivo number in seconds");
        } else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name)
    {
		Debug.Log ("Level load requested: "+name);
		Application.LoadLevel (name);
	}

	public void Quit()
    {
		Debug.Log ("Quit level requested");
		Application.Quit();
	}
	
	public void BackToStart(string name)
    {
		Debug.Log ("Back to start requested");
		Application.LoadLevel (name);
    }
	
	public void LoadNextLevel()
    {
		Application.LoadLevel(Application.loadedLevel+1);
                
        PlayerPrefsManager.SetLastLevel(Application.loadedLevel);

        Debug.Log("Next level requested");
    }

    public void LoadLastLevel()
    {
        int lastLevelLoaded = (int)PlayerPrefsManager.GetLastLevel();

        if (lastLevelLoaded == 0)
        {
            Application.LoadLevel("02 Level_01");
        }
        if (lastLevelLoaded == 3)
        {
            Application.LoadLevel("02 Level_02");
        }
        if (lastLevelLoaded == 4)
        {
            Application.LoadLevel("02 Level_03");
        }
        if (lastLevelLoaded == 5)
        {
            Application.LoadLevel("02 Level_04");
        } 
    }


       
}