using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

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
            taskUI.transform.SetParent(listOfTasksGO.transform);
            taskUI.GetComponentInChildren<TMP_Text>().text = $"Client: {task.TaskClient.FirstName} {task.TaskClient.Surname}, dog: {task.TaskDog.DogName}, where: {task.TaskAddress.transform.position}, money: {task.TaskPrice}";
            //taskUI.GetComponent<RectTransform>().SetAsLastSibling();
        }
    }

    /*
    void clearChildrenOfListOfTasks(GameObject go)
    {
        foreach (Transform child in go.transform)
        {
            if(child.GetComponent<Image>() == null)
                Destroy(child.gameObject);
        }
    }
    */
    


}
