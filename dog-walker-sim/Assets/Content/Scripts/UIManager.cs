using UnityEngine;

public class UIManager : MonoBehaviour, IUIHandler
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    //UI
    [SerializeField] private GameObject canvasHandler;

    [SerializeField] private GameObject logHandler; public bool LogOpened { get { return logHandler.activeSelf; } }
    [SerializeField] private GameObject listOfTasksGO;
    [SerializeField] private GameObject detailOfTaskGO;

    [SerializeField] private GameObject taskCompUI;
    ///


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

    private void Start()
    {

        TurnOffUI();
    }

    private void TurnOffUI()
    {
        canvasHandler.SetActive(false);
        logHandler.SetActive(false);
    }

    public void OpenLog()
    {
        if (!canvasHandler.activeSelf)
            canvasHandler.SetActive(true);

        logHandler.SetActive(true);
    }

    public void CloseLog()
    {
        logHandler.SetActive(false);
        canvasHandler.SetActive(false);
    }

    public void CreateUITask()
    {
        throw new System.NotImplementedException();
    }
}
