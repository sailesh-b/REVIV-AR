using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ARController : MonoBehaviour
{
    public ARSession arSession; // Reference to AR Session
    public Button startCaptureButton; // Reference to the Start Capture button
    public Button goBackButton; // Reference to the Go Back button

    [SerializeField] private GameObject defaultCanvas;

    void Start()
    {
        // Ensure AR session is initially disabled
        if (arSession != null)
        {
            arSession.gameObject.SetActive(false);
            Debug.Log("AR Session initially disabled.");
        }

        // Add listener to the Start Capture button
        if (startCaptureButton != null)
        {
            startCaptureButton.onClick.AddListener(StartCapturing);
            Debug.Log("Start Capture Button listener added.");
        }
        //else
        //{
        //    Debug.LogWarning("Start Capture Button is not assigned.");
        //}

        // Set up the Go Back button
        if (goBackButton != null)
        {
            goBackButton.onClick.AddListener(StopCapturing);
            goBackButton.gameObject.SetActive(false); // Hide Go Back initially
        }


    }

    void StartCapturing()
    {
        // Enable the AR session to start capturing
        if (arSession != null)
        {
            arSession.gameObject.SetActive(true);
            defaultCanvas.SetActive(false);
            goBackButton.gameObject.SetActive(true); // Show Go Back button
            Debug.Log("AR Session started.");
        }
        else
        {
            Debug.LogWarning("AR Session is not assigned.");
        }
    }

    public void StopCapturing()
    {
        // Stop AR session and return to the main UI
        arSession.gameObject.SetActive(false);
        defaultCanvas.SetActive(true);
        // goBackButton.gameObject.SetActive(false); // Hide Go Back button
        Debug.Log("AR Session stopped");
    }
}
