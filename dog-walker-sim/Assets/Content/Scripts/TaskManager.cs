using System.Collections;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private static TaskManager instance;

    public static TaskManager Instance { get { return instance; } }

    [SerializeField] private Task activeTask; public Task ActiveTask { get { return activeTask; } set { activeTask = value; } }

    [SerializeField] private GameObject playersDogPlace;


    Transform nosePos;
    GameObject dog;

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
        activeTask = null;
        UIManager.Instance.OnCancelTask += CancelActiveTask;
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

    private void CancelActiveTask()
    {
        activeTask = null;
        Debug.Log($"At {this}, nulled AT: {activeTask == null}");
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
        Debug.Log($"Invoked init dodge");
        if (activeTask != null)
        {
            if (activeTask.TaskAddress.gameObject.name == address.name)
            {
               
                Debug.Log($"Dog {activeTask.TaskDog.DogName} spawned");
                var dogGO = Instantiate(activeTask.TaskDog.DogGO, playersDogPlace.transform);

                foreach (Transform tr in dogGO.transform)
                {
                    if(tr.name == "Nose")
                    {
                        nosePos = tr;
                        Debug.Log("Nosed");

                    }
                    
                    if(tr.gameObject.tag == "Dog")
                    {
                        dog = tr.gameObject;
                    }
                }


                
                dog.transform.LookAt(nosePos); ;

                if (dogGO.GetComponent<DogUIRenderer>() != null)
                {
                    dogGO.GetComponent<DogUIRenderer>().SetName(activeTask.TaskDog.DogName);
                }
            }
        }
    }
}
