using System.Collections;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private static TaskManager instance;

    public static TaskManager Instance { get { return instance; } }

    [SerializeField] private Task activeTask; public Task ActiveTask { get { return activeTask; } set { activeTask = value; } }

    [SerializeField] private GameObject playersDogPlace;

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
        activeTask = new Task(new Client(0, "test", "test", null, new Dog(0, "test", 0, 0, 0, 0, null)),
           new Dog(0, "test", 0, 0, 0, 0, null), 0f);
    }

    public void printActiveTask()
    {
        Debug.Log($"At {this} ActiveTask: {activeTask.ID}, {activeTask.TaskClient.FirstName} {activeTask.TaskClient.Surname}, {activeTask.TaskDog.DogName}, {activeTask.TaskAddress.transform.position}, {activeTask.TaskPrice}");
    }

    public void SetActiveTask(Task task)
    {
        this.activeTask = task;
        printActiveTask();
        //StartCoroutine(TillTaskStartCountdown(task));
    }

    private IEnumerator TillTaskStartCountdown(Task task)
    {
        yield return new WaitForSeconds(10f);
        if (!task.IsTaskStarted)
        {
            Debug.Log($"Runned of time for task {task.ID}, {task.TaskClient.FirstName} {task.TaskClient.Surname}, {task.TaskDog.DogName}");
            task = null;
            activeTask = null;


        }
    }

    private IEnumerator TimeForTaskDone(Task task)
    {
        yield return null;
    }

    public void InstantiateDogkFromTask(GameObject address)
    {
        if (activeTask.TaskAddress.gameObject.name == address.name)
        {
            Debug.Log($"Dog {activeTask.TaskDog.DogName} spawned");
            var dogGO = Instantiate(activeTask.TaskDog.DogGO, playersDogPlace.transform);
            if (dogGO.GetComponent<DogUIRenderer>() != null)
            {
                dogGO.GetComponent<DogUIRenderer>().setName(activeTask.TaskDog.DogName);
            }
        }
    }
}
