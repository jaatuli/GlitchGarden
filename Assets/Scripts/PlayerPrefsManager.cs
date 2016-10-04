using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string HAS_PLAYED = "has_played";

	public static void SetMasterVolume (float volume)
    {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume outside 0-1 f");

        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel (int level)
    {
        if (level <= SceneManager.sceneCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true, 0 for false
        } else
        {
            Debug.LogError("Trying to unlock level outside build list");
        }
    }

    public static bool IsLevelUnlocked (int level)
    {
        if (level <= SceneManager.sceneCount - 1)
        {
            int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
            bool isLevelUnlocked = (levelValue == 1);
            return isLevelUnlocked;
            
        }
        else
        {
            Debug.LogError("Trying to query level outside build list");
            return false;
        }
    }

    public static void SetDifficulty (float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty outside 1-3 f");

        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetHasPlayed() {

        PlayerPrefs.SetInt(HAS_PLAYED, 1);
    }

    public static int GetHasPlayed() {
        return PlayerPrefs.GetInt(HAS_PLAYED);
    }
}
