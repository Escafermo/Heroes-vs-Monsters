using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelTime;
    public bool isEndLevel = false;

    private Slider slider;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private GameObject winLabel;

    void Start ()
    {
        slider = GetComponent<Slider>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        audioSource = GetComponent<AudioSource>();

        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("Create WIN object");
        }
        winLabel.SetActive(false);
    }

    

    void Update ()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;

        bool timeIsUp = (Time.timeSinceLevelLoad >= levelTime);
        if (timeIsUp && !isEndLevel)
        {
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length+3);
            isEndLevel = true;   
        }
	}

    void LoadNextLevel ()
    {
        levelManager.LoadNextLevel();
    }

}
