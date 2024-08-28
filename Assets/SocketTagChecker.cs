using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketTagChecker : MonoBehaviour
{
    public string requiredTag;
    public ParticleSystem successParticle;

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
            Debug.Log("Correct book placed!");
            isCorrectlyPlaced = true;
            successParticle.Play();
            AudioManager.Instance.PlayPositiveActionSound();
        }
        else
        {
            Debug.Log("Incorrect book.");
            isCorrectlyPlaced = false;
            successParticle.Stop();
            AudioManager.Instance.PlayNegativeActionSound();
        }
    }

    private void OnBookRemoved(SelectExitEventArgs args)
    {
        if (isCorrectlyPlaced)
        {
            Debug.Log("Book removed from correct socket.");
            isCorrectlyPlaced = false;
            successParticle.Stop();
            AudioManager.Instance.StopSounds();
        }
        else
        {
            Debug.Log("Book removed from incorrect socket.");
            AudioManager.Instance.StopSounds();
        }
    }
}
