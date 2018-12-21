using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TEST
{
    public class SecondECSLaunch : MonoBehaviour
    {
        [SerializeField] private Button classicBtn;
        [SerializeField] private Button jobSystemBtn;

        void Start()
        {
            classicBtn.onClick.AddListener(ClassicBtnClick);
            jobSystemBtn.onClick.AddListener(jobSystemBtnClick);
        }

        void ClassicBtnClick()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        void jobSystemBtnClick()
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
}
