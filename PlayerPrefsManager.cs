using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "dificulty";
    const string LEVEL_UNLOCKED_KEY_ = "level_unlocked_";
    const string LAST_LEVEL = "01a Start";

    public static void SetLastLevel (float lastLevel)
    {
        PlayerPrefs.SetFloat(LAST_LEVEL, lastLevel);
        
    }

    public static float GetLastLevel()
    {
        return PlayerPrefs.GetFloat(LAST_LEVEL);
    }

   
    public static void SetMasterVolume (float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel (int level)
    {
        if (level < Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_UNLOCKED_KEY_ + level.ToString(),1); //1 is used for true
        } else
        {
            Debug.LogError("Can't load level not in build order");
        }
    }

    public static bool IsLevelUnlocked (int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_UNLOCKED_KEY_ + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= Application.levelCount - 1)
        {
            return isLevelUnlocked;
        } else
        {
            Debug.LogError("Can't query level not in build order ");
            return false;
        }

    }

    
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    

}
