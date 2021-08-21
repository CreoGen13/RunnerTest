using UnityEngine;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.UI;

[Game, Unique, CreateAssetMenu]
public class GlobalVariables : ScriptableObject
{
    public Material glowFadingMaterial;
    public GameObject EnemyPrefab;
    public GameObject CoinPrefab;
    public GameObject DeathParticlePrefab;

    [HideInInspector]
    public GameObject LevelPart1;
    [HideInInspector]
    public GameObject LevelPart2;
    [HideInInspector]
    public GameObject Player;
    [HideInInspector]
    public Animator Level;
    [HideInInspector]
    public GameObject SwipeControllerGameObject;
    [HideInInspector]
    public GameObject BattleButtons;
    [HideInInspector]
    public Text ScoreText;
    [HideInInspector]
    public GameObject GameOver;

    public GameObject LevelVariant1;
    public GameObject LevelVariant2;
    public GameObject LevelVariant3;
    public GameObject LevelVariant4;

}
