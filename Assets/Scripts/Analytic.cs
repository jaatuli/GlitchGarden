using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Analytic : MonoBehaviour {

   public static void LevelEndAnalytics(bool wonLevel) {

        int finishedLevel = SceneManager.GetActiveScene().buildIndex - 2;
        int difficulty = Mathf.RoundToInt(PlayerPrefsManager.GetDifficulty());
        int starCount = GameObject.FindObjectOfType<StarDisplay>().starCount;

        Analytics.CustomEvent("levelEnd", new Dictionary<string, object> {
            {"level",finishedLevel },
            {"wonLevel",wonLevel },
            {"difficulty",difficulty },
            {"stars", starCount }
        });
    }

}
