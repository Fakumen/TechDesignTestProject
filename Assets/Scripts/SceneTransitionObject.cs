using UnityEngine;
using UnityEngine.SceneManagement;

namespace TechDesignTestProject
{
    public class SceneTransitionObject : MonoBehaviour
    {
        [SerializeField]
        private int _sceneBuildId;

        public void LoadNextScene()
        {
            if (SceneManager.sceneCountInBuildSettings <= _sceneBuildId)
                return;
            SceneManager.LoadScene(_sceneBuildId);
        }
    }
}