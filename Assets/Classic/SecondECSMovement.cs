using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TEST
{
    public class SecondECSMovement : MonoBehaviour
    {
        void Update()
        {
            Vector3 pos = transform.position;
            pos += transform.forward * SecondECSGameManager.ins.EnemySpeed * Time.deltaTime;

            if (pos.z < SecondECSGameManager.ins.BottonBound)
                pos.z = SecondECSGameManager.ins.TopBound;

            transform.position = pos;
        }
    }
}
