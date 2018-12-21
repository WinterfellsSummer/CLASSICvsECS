using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TEST
{
    public class SecondECSFPS : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Button backBtn;
        [SerializeField] private float showTime = 1f;

        private int count = 0;
        private float deltaTime = 0f;
        float fps = 0f;
        float milliSecond = 0f;
        void Start()
        {
            backBtn.onClick.AddListener(BackBtnClick);
        }

        void Update()
        {
            count++;
            deltaTime += Time.deltaTime;
            if (deltaTime >= showTime)
            {
                fps = count / deltaTime;
                milliSecond = deltaTime * 1000 / count;
                //string strFpsInfo = string.Format(" 当前每帧渲染间隔：{0:0.0} ms ({1:0.} 帧每秒)", milliSecond, fps);
                count = 0;
                deltaTime = 0f;
            }
            text.text = "FPS: " + fps.ToString("f2") + "(" + milliSecond.ToString("f2") + "ms)" + "\nCount: " + shipCount.ToString();
        }

        private int shipCount = 0;
        public void SetCount(int value)
        {
            shipCount = value;
        }

        void BackBtnClick()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
