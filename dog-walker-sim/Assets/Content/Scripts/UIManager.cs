using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public TaskEvent SetActiveTaskEvent;
    public TaskEvent DestroyTaskEvent;

    //UI
    [SerializeField] private GameObject canvasHandler;

    [SerializeField] private GameObject logHandler; public bool LogOpen { get { return logHandler.activeSelf; } }
    [SerializeField] private GameObject listOfTasksGO;

    [SerializeField] private GameObject taskCompUI;

    [SerializeField] private GameObject detailOfTaskGO;
    [SerializeField] private GameObject contentGO;

    [SerializeField] private TMP_Text clientText;
    [SerializeField] private TMP_Text dogText;
    [SerializeField] private TMP_Text taskDetailsText;

    private static string sClientText;
    private static string sDogText;
    private static string sTasksDetailsText;

    private GameObject[] btns;

    private int lastChosenIndex;
    private GameObject lastChosenButton;
    private Task lastChosenTask;
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

        InitEvents();

        ResetTextDetails();
    }

    private void InitEvents()
    {
        if (SetActiveTaskEvent == null) SetActiveTaskEvent = new TaskEvent();
        SetActiveTaskEvent.AddListener(TaskManager.Instance.SetActiveTask);

        if (DestroyTaskEvent == null) DestroyTaskEvent = new TaskEvent();
        DestroyTaskEvent.AddListener(TaskGenerator.Instance.DestroyChosenTask);
    }

    private void TurnOffUI()
    {

        //init (?)
        canvasHandler.SetActive(true);
        logHandler.SetActive(true);
        //

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

        foreach (Transform child in listOfTasksGO.transform)
        {
            if (child.GetComponent<Image>() == null)
                Destroy(child.gameObject);
        }

        foreach (Task task in TaskGenerator.Instance.TasksList)
        {
            var taskUI = Instantiate(taskCompUI);
            taskUI.transform.SetParent(listOfTasksGO.transform, false);
            taskUI.GetComponentInChildren<TMP_Text>().text = $"Client: {task.TaskClient.FirstName} {task.TaskClient.Surname}, dog: {task.TaskDog.DogName}, where: {task.TaskAddress.transform.position}, money: {task.TaskPrice}";
            taskUI.GetComponent<Button>().onClick.AddListener(() => this.GetClickedButton(taskUI));
        }
    }

    public void GetClickedButton(GameObject button)
    {
        Debug.Log($"At {this}, clicked {button.name}:{button.GetInstanceID()}");

        btns = GameObject.FindGameObjectsWithTag("TaskCompUI");

        int index = 0;
        foreach (GameObject btn in btns)
        {


            if (btn == button)
            {
                lastChosenButton = button;
                lastChosenIndex = index;
                Debug.Log($"Match: {btn.GetInstanceID()} == {button.GetInstanceID()}");

                Debug.Log("\n");
                //TaskManager.Instance.ActiveTask = TaskGenerator.Instance.TasksList[index];
                lastChosenTask = TaskGenerator.Instance.TasksList[index];

                break;

            }
            index++;


        }
        SetDetailsOfTask(lastChosenTask);


    }

    public void SetActiveTask()
    {

        SetActiveTaskEvent?.Invoke(lastChosenTask);
        DestroyTaskEvent?.Invoke(lastChosenTask);

        foreach (GameObject btn in btns)
        {
            if (btn == lastChosenButton)
            {
                Destroy(btn);
            }
        }

    }

    public void DeclineTask()
    {
        foreach (GameObject btn in btns)
        {
            if (btn == lastChosenButton)
            {
                DestroyTaskEvent?.Invoke(lastChosenTask);
                Destroy(btn);
            }
        }
        ResetTextDetails();
    }



    void SetDetailsOfTask(Task task)
    {


        sClientText = $"Client: {task.TaskClient.FirstName} {task.TaskClient.Surname}";
        //clientText.text = $"Client: {task.TaskClient.FirstName} {task.TaskClient.Surname}";


        sDogText = $"Dog: {task.TaskDog.DogName}, agressivness: {(int)task.TaskDog.DogAgressivness}, LTL: {(int)task.TaskDog.DogListeningToLeader}, SFP: {(int)task.TaskDog.DogSympathyForPlayer}";
        //dogText.text = $"Dog: {task.TaskDog.DogName}, agressivness: {task.TaskDog.DogAgressivness}, LTL: {task.TaskDog.DogListeningToLeader}, SFP: {task.TaskDog.DogSympathyForPlayer}";


        sTasksDetailsText = $"Task details: Place: {task.TaskAddress.name} at {task.TaskAddress.transform.position}, for: ${task.TaskPrice}";
        //taskDetailsText.text = $"Task details: Place: {task.TaskAddress.name} at {task.TaskAddress.transform.position}, for: ${task.TaskPrice}";

        UpdateTextObjects(sClientText, sDogText, sTasksDetailsText);

    }

    void ResetTextDetails()
    {
        UpdateTextObjects("", "", "");
    }

    void UpdateTextObjects(string clientT, string dogT, string taskDetailsT)
    {
        clientText.text = clientT;
        dogText.text = dogT;
        taskDetailsText.text = taskDetailsT;

    }

    /*
    void SetDetailsOfTask(Task task)
    {


        clientText.text = $"Client: {task.TaskClient.FirstName} {task.TaskClient.Surname}";
        //clientText.text = $"Client: {task.TaskClient.FirstName} {task.TaskClient.Surname}";


        dogText.text = $"Dog: {task.TaskDog.DogName}, agressivness: {(int)task.TaskDog.DogAgressivness}, LTL: {(int)task.TaskDog.DogListeningToLeader}, SFP: {(int)task.TaskDog.DogSympathyForPlayer}";
        //dogText.text = $"Dog: {task.TaskDog.DogName}, agressivness: {task.TaskDog.DogAgressivness}, LTL: {task.TaskDog.DogListeningToLeader}, SFP: {task.TaskDog.DogSympathyForPlayer}";


        taskDetailsText.text = $"Task details: Place: {task.TaskAddress.name} at {task.TaskAddress.transform.position}, for: ${task.TaskPrice}";
        //taskDetailsText.text = $"Task details: Place: {task.TaskAddress.name} at {task.TaskAddress.transform.position}, for: ${task.TaskPrice}";

    }
    */



}
