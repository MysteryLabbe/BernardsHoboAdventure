using System.Collections;
using System.Collections.Generic;
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

        [SerializeField] private GameObject _unitPrefab;

        private Unit[] _unitList; 

        public void InitializeUnits()
        {
            _unitList = new Unit[16];

            for (int i = 0; i < 4; i++)
            {
                GameObject unit = Instantiate(_unitPrefab, new Vector3((i * 2)-3, 0.5f, 3), Quaternion.identity, this.transform);
                unit.name = $"unit_{i}";
                Unit unitScript = unit.GetComponent<Unit>();
                _unitList[i] = unitScript;
            }
        }
    }
}