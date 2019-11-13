using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalVariablesMenu : MonoBehaviour {

    public static int levelNumber;
    public static LevelList levelList;

	public void LoadLevel(Button button)
    {
        levelNumber = int.Parse(button.GetComponentInChildren<Text>().text);

        Debug.Log("Loading level " + levelNumber);

        SceneManager.LoadScene("GameScene");
    }

    private void OnEnable()
    {
        levelNumber = 0;
        TextAsset levelData = (TextAsset)Resources.Load("Levels");
        string jsonLevelString = levelData.text;
        levelList = JsonUtility.FromJson<LevelList>(jsonLevelString);
        Debug.Log(levelList.levels[levelNumber+1].ToString());
    }
}
