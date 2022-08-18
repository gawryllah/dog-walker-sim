using UnityEngine;

public class GameManager : MonoBehaviour, IUIHandler
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public bool GameOn { get; set; } = false;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);
    }



    // Start is called before the first frame update
    void Start()
    {
        GameOn = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenLog()
    {
        Debug.Log($"Opened log");
        Time.timeScale = 0f;
        UIManager.Instance.OpenLog();

    }

    public void CloseLog()
    {
        Debug.Log($"Closed log");
        Time.timeScale = 1f;
        UIManager.Instance.CloseLog();
    }

    public void CreateUITask()
    {
        throw new System.NotImplementedException();
    }
}
