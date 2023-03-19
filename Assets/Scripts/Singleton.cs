using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public GameObject me;

    private AudioSource _bg;

    private void Awake()
    {
        #region Singelton
        List<Singleton> me = FindObjectsOfType<Singleton>().ToList();

       
        if (me != null)
        {
            for (int i = 0; i < me.Count; i++)
            {

                print(me[i].name);

                if (me[i] != this)
                    Destroy(me[i]);
                else
                    DontDestroyOnLoad(this);
            }
        }
        else
            DontDestroyOnLoad(this);
        #endregion
    }

}