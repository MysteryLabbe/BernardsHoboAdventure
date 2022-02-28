using Assets.Scripts.GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Dependencies ////////////
    private UnitManager _unitManager;
    ////////////////////////////

    // Singleton ///////////////
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }
    ////////////////////////////

    void Awake()
    {
        // Initialize dependencies
        _unitManager = UnitManager.Instance;
    }

    void Start()
    {
        // Initialize game
        Debug.Log("Game started !");

        Debug.Log("Spawning units...");
        _unitManager.InitializeUnits();

    }
    
    void Update()
    {
        
    }
}
