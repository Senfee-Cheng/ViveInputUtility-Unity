
using System.Collections;
using QFramework;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncOperationLoadScene : MonoBehaviour
{
    public static AsyncOperationLoadScene instance;
    public Slider slider;
    readonly ScheduledNotifier<float> progressObservable = new ScheduledNotifier<float>();
    private int _currentProgress;
    private AsyncOperation _async;
    bool clicking;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        _currentProgress = 0;
        DisposableExtensions.AddTo(Observable.EveryUpdate().Subscribe(_ => { slider.value = _currentProgress; }), this);
    }

    public void AsyncLoadScene(string sceneName)
    {
        if (clicking)
        {
            return;
        }
        clicking = true;
        LoadScene(sceneName).ToObservable().Subscribe(_ => clicking = false);
            
    }

    IEnumerator LoadScene(string sceneName)
    {
        int tmp;
        _async = SceneManager.LoadSceneAsync(sceneName);
        _async.AsAsyncOperationObservable(progressObservable).Subscribe(_ => { Debug.Log("Load Done"); });
        _async.allowSceneActivation = false;

        while (_async.progress < 0.9f)
        {
            //相当于滑动条应该到的位置
            tmp = (int) _async.progress * 100;

            //当滑动条 < tmp 就意味着滑动条应该变化
            while (_currentProgress < tmp)
            {
                ++_currentProgress;
                yield return new WaitForEndOfFrame();
            }
        }

        tmp = 100;
        while (_currentProgress < tmp)
        {
            ++_currentProgress;
            yield return new WaitForEndOfFrame();
        }

        _async.allowSceneActivation = true;
    }
}