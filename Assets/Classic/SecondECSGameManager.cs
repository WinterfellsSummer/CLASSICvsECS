using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TEST
{
    public class SecondECSGameManager : MonoBehaviour
    {
        #region GAME_MANAGE_STUFF
        [Header("Simulation Settings")]
        [SerializeField] private float _topBound = 16.5f;
        [SerializeField] private float _bottonBound = -13.5f;
        [SerializeField] private float _leftBound = -23.5f;
        [SerializeField] private float _rightBound = 23.5f;

        [Header("Enemy Settings")]
        [SerializeField] private GameObject _enemyShipPrefab;
        [SerializeField] private float _enemySpeed = 1f;

        [Header("Spawn Settings")]
        [SerializeField] private int _enemyShipCount = 1;
        [SerializeField] private int _enemyShipIncremement = 1;

        public static SecondECSGameManager ins;

        public float EnemySpeed
        {
            get
            {
                return _enemySpeed;
            }
        }
        public float TopBound
        {
            get
            {
                return _topBound;
            }
        }
        public float BottonBound
        {
            get
            {
                return _bottonBound;
            }
        }

        private void Awake()
        {
            ins = this;
            fps = GetComponent<SecondECSFPS>();
        }
        private int amountCount = 0;
        private SecondECSFPS fps;
        #endregion

        private void Start()
        {
            AddShips(_enemyShipCount);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                AddShips(_enemyShipIncremement);
        }


        public void AddShips(int count)
        {
            for (int i = 0; i < count; i++)
            {
                float xval = Random.Range(_leftBound, _rightBound);
                float yval = UnityEngine.Random.Range(-5f, 5f);
                float zval = Random.Range(0f, 10f);

                Vector3 pos = new Vector3(xval, yval, zval + _topBound);
                Quaternion rot = Quaternion.Euler(0f, 180f, 0f);

                var obj = Instantiate(_enemyShipPrefab, pos, rot) as GameObject;
            }

            amountCount += count;
            fps.SetCount(amountCount);
        }
    }
}