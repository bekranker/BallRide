using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    [SerializeField] bool IsCanRestartTheLevel = false;
    [SerializeField] Animator _animation;
    [SerializeField] List<GameObject> ScoreImage = new List<GameObject>();
    [SerializeField] GameObject _WinPanel;
    private void Start()
    {
        StartCoroutine(Wait());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && IsCanRestartTheLevel)
        {
            StartCoroutine(Restart());
        }
    }
    public void SetActiveImages()
    {
        Score++;
        for (int i = 0; i < Score; i++)
        {
            ScoreImage[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        if (Score >= 10)
        {
            _WinPanel.SetActive(true);
        }
    }

    public void NextSceneF() => StartCoroutine(GoScene(SceneManager.GetActiveScene().buildIndex + 1));
    public void returnHome()
    {
        StartCoroutine(GoScene(0));
    }
    IEnumerator GoScene(int index)
    {
        _animation.SetTrigger("Out");
        yield return new WaitForSecondsRealtime(1f);
        if(SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(index);
        else
            SceneManager.LoadScene(0);
    }
    IEnumerator Restart()
    {
        IsCanRestartTheLevel = false;
        _animation.SetTrigger("Out");
        yield return new WaitForSecondsRealtime(.30f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1);
        IsCanRestartTheLevel = true;
    }
}
