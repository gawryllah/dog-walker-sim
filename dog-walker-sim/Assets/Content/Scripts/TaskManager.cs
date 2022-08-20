using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private static TaskManager instance;

    public static TaskManager Instance { get { return instance; } }

    [SerializeField] private Task activeTask; public Task ActiveTask { get { return activeTask; } set { activeTask = value; } }

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

    public void PrintActiveTask()
    {
        Debug.Log($"At {this} ActiveTask: {activeTask.ID}, {activeTask.TaskClient.FirstName} {activeTask.TaskClient.Surname}, {activeTask.TaskDog.DogName}, {activeTask.TaskAddress.transform.position}, {activeTask.TaskPrice}");
    }
}
