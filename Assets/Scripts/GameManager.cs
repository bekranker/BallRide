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
        if(Score + 1 >= 10)
        {
            StartCoroutine(NextScene());
            return;
        }
        Score++;
        for (int i = 0; i < Score; i++)
        {
            ScoreImage[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
    }
    IEnumerator NextScene()
    {
        _animation.SetTrigger("Out");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
