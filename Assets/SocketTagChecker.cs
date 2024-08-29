using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketTagChecker : MonoBehaviour
{
    public string requiredTag;
    public ParticleSystem successParticle;
    public EscapeRoomManager escapeRoomManager;
    public int puzzleIndex;
    public int conditionIndex; // El índice de la condición para este libro específico

    private XRSocketInteractor socketInteractor;
    private bool isCorrectlyPlaced = false;

    private void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(OnBookInserted);
        socketInteractor.selectExited.AddListener(OnBookRemoved);
    }

    private void OnBookInserted(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag(requiredTag))
        {
            isCorrectlyPlaced = true;
            successParticle.Play();
            AudioManager.Instance.PlayPositiveActionSound();
            escapeRoomManager.SetPuzzleCondition(puzzleIndex, conditionIndex, true);
            escapeRoomManager.CheckPuzzleCompletion();
        }
        else
        {
            isCorrectlyPlaced = false;
            successParticle.Stop();
            AudioManager.Instance.PlayNegativeActionSound();
        }
    }

    private void OnBookRemoved(SelectExitEventArgs args)
    {
        if (isCorrectlyPlaced)
        {
            isCorrectlyPlaced = false;
            successParticle.Stop();
            AudioManager.Instance.StopSounds();
            escapeRoomManager.SetPuzzleCondition(puzzleIndex, conditionIndex, false);
        }
        else
        {
            AudioManager.Instance.StopSounds();
        }
    }
}
