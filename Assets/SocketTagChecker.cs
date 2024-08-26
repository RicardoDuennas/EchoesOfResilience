using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketTagChecker : MonoBehaviour
{
    public string requiredTag;
    public ParticleSystem successParticle;

    private XRSocketInteractor socketInteractor;

    private void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(CheckTag);
    }

    private void CheckTag(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag(requiredTag))
        {
            Debug.Log("Correct book placed!");
            if (successParticle != null)
            {
                successParticle.Play();
            }
            // Trigger any additional logic for the correct book
        }
        else
        {
            Debug.Log("Incorrect book.");
            // Optionally remove the wrong book or provide feedback
        }
    }
}
