using UnityEngine;

public class TaskDestination : MonoBehaviour, IInteractable
{
    public TaskDestinationEvent taskDogPass;
    private GameObject go;

    private void InitEvents()
    {
        if (taskDogPass == null) taskDogPass = new TaskDestinationEvent();
        taskDogPass.AddListener(TaskManager.Instance.InstantiateDogkFromTask);
    }

    private void Awake()
    {

        go = transform.gameObject;
    }

    private void Start()
    {

        InitEvents();
    }

    public void Interact()
    {
        Debug.Log($"Intercated with: {this.name}");
        taskDogPass?.Invoke(go);
    }


}
