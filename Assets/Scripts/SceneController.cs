using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneController{
    public class SceneController : MonoBehaviour
    {


        public static void LoadTargetScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}

