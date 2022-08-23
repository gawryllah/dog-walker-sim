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

    private void Start()
    {
        InitEvents();
        go = transform.gameObject;
    }

    public void Interact()
    {
        Debug.Log($"Intercated with: {this.name}");
        taskDogPass?.Invoke(go);
    }


}
