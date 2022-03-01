using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class UnitManager : MonoBehaviour
    {
        // Dependencies ////////////
        ////////////////////////////

        // Singleton ///////////////
        private static UnitManager _instance;
        public static UnitManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<UnitManager>();
                    if (_instance == null)
                    {
                        _instance = new GameObject("UnitManager").AddComponent<UnitManager>();
                    }
                }

                return _instance;
            }
        }
        ////////////////////////////

        private Vector3[] _spawnPoints = new Vector3[4] {
            new Vector3(-2.49f, 0.5f, -3.53f),
            new Vector3(-1.86f, 0.5f, 2.5f),
            new Vector3(4.1f, 0.5f, 3.41f),
            new Vector3(3.57f, 0.5f, -3.32f)
        };

        [SerializeField] private GameObject _unitPrefab;

        private Unit[] _unitList; 

        public void InitializeUnits()
        {
            _unitList = new Unit[16];

            System.Random rdm = new System.Random();
            Vector3[] randomizedSpawnPoints = _spawnPoints.OrderBy(a => rdm.Next()).ToArray();

            for (int i = 0; i < 4; i++)
            {
                GameObject unit = Instantiate(_unitPrefab, randomizedSpawnPoints[i], Quaternion.identity, this.transform);
                unit.name = $"unit_{i}";
                Unit unitScript = unit.GetComponent<Unit>();
                _unitList[i] = unitScript;
            }
        }
    }
}