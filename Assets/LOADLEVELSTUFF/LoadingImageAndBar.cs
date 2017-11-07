using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingImageAndBar : MonoBehaviour {

    public Slider loadingBar;
    public GameObject loadingObject;

    private AsyncOperation async;

    public void LoadLevelAsync(int level)
    {
        loadingObject.SetActive(true);
        StartCoroutine(LoadTheLevel(level));
    }

    IEnumerator LoadTheLevel(int level)
    {
        async = SceneManager.LoadSceneAsync(level);
        
        while (!async.isDone)
        {
            print(async.progress);
            loadingBar.value = async.progress;
            yield return null;
        }
    }
}
