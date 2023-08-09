using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private List<GameObject> lstGameObj;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        foreach (GameObject obj in lstGameObj)
        {
            DontDestroyOnLoad(obj);
        }
    }


    public void LoadScenes(int id)
    {
        SceneManager.LoadSceneAsync(id, LoadSceneMode.Single);
        lstGameObj[0].SetActive(false);
    }

    public void BackHome()
    {
        Scene current = SceneManager.GetActiveScene();
        if (current.name == "Home") return;
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        lstGameObj[0].SetActive(true);
    }


}
