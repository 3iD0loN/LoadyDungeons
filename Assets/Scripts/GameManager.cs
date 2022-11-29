using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    
    public static int s_CurrentLevel = 0;

    public static int s_MaxAvailableLevel = 5;

    // The value of -1 means no hats have been purchased
    public static int s_ActiveHat = 0;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnEnable()
    {
        // When we go to the 
        s_CurrentLevel = 0;
        var gameLogoImage = GameObject.Find("Game Logo").GetComponent<Image>();

        var logoResourceRequest = Resources.LoadAsync("LoadyDungeonsLogo");
        logoResourceRequest.completed += (asyncOperation) =>
        {
            gameLogoImage.sprite = logoResourceRequest.asset as Sprite;
        };
    }

    public void ExitGame()
    {
        s_CurrentLevel = 0;
    }

    public void SetCurrentLevel(int level)
    {
        s_CurrentLevel = level;
    }

    public static void LoadNextLevel()
    {
        Resources.LoadAsync("LoadingScene");
    }

    public static void LevelCompleted()
    {
        s_CurrentLevel++;

        // Just to make sure we don't try to go beyond the allowed number of levels.
        s_CurrentLevel = s_CurrentLevel % s_MaxAvailableLevel;

        LoadNextLevel();
    }

    public static void ExitGameplay()
    {
        Resources.LoadAsync("MainMenu");
    }

    public static void LoadStore()
    {
        Resources.LoadAsync("Store");
    }
}
