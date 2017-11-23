using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsControler : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	void Update () {
        musicManager.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);

        levelManager.LoadLevel("01a Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }




}
