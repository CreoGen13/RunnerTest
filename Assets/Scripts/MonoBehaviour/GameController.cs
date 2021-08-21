using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GlobalVariables globalVariables;
    public Transform spawnPoint;

    public Animator level;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject battleButtons;
    public GameObject swipeControllerGO;
    public GameObject player;
    public GameObject levelPart1;
    public GameObject levelPart2;

    [HideInInspector]
    public static Contexts contexts;

    private RootSystems systems;
    void Start()
    {
        contexts = Contexts.sharedInstance;

        InitializeGlobalVarialbles();

        systems = new RootSystems(contexts);
        systems.Initialize();
    }
    void Update()
    {
        systems.Execute();
    }
    void InitializeGlobalVarialbles()
    {
        globalVariables.GameOver = gameOver;
        globalVariables.ScoreText = scoreText;
        globalVariables.LevelPart1 = levelPart1;
        globalVariables.LevelPart2 = levelPart2;
        globalVariables.BattleButtons = battleButtons;
        globalVariables.SwipeControllerGameObject = swipeControllerGO;
        globalVariables.Player = player;
        globalVariables.Level = level;

        contexts.game.SetGlobalVariables(globalVariables);
    }
}
