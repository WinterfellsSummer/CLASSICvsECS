using System.Collections;
using Unity.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace TEST
{
    public class SecondECSGameManagerJobSystem : MonoBehaviour
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

        public static SecondECSGameManagerJobSystem ins;

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

        EntityManager manager;

        private void OnDisable()
        {
            NativeArray<Entity> allEntities = manager.GetAllEntities();
            manager.DestroyEntity(allEntities);
            allEntities.Dispose();
        }

        private void Start()
        {
            manager = World.Active.GetOrCreateManager<EntityManager>();
            AddShips(_enemyShipCount);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                AddShips(_enemyShipIncremement);
        }


        public void AddShips(int count)
        {
            NativeArray<Entity> entities = new NativeArray<Entity>(count, Allocator.Temp);
            manager.Instantiate(_enemyShipPrefab, entities);
            for (int i = 0; i < count; i++)
            {
                float xval = UnityEngine.Random.Range(_leftBound, _rightBound);
                float yval = UnityEngine.Random.Range(-5f, 5f);
                float zval = UnityEngine.Random.Range(0f, 10f);
                manager.SetComponentData(entities[i], new Position { Value = new float3(xval, yval, TopBound + zval) });
                manager.SetComponentData(entities[i], new Rotation { Value = new quaternion(0, 1, 0, 0) });
                manager.SetComponentData(entities[i], new MoveSpeed { Value = EnemySpeed });
            }
            entities.Dispose();

            amountCount += count;
            fps.SetCount(amountCount);
        }
    }
}