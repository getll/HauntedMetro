using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class DoorwayScript : MonoBehaviour
{
    public TMP_Text interactText;
    public GameObject fadePanel;
    public float fadeDuration = 5f;
    public string sceneToLoad = "MetroCutscene";
    public float interactDistance = 2f;
    public LayerMask interactLayer;

    private bool playerInRange = false;
    public FirstPersonController playerMovement;

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.enabled = false;
            StartCoroutine(FadeToBlack());
        }
    }

    private void FixedUpdate()
    {
        Transform player = Camera.main.transform;
        Vector3 direction = (transform.position - player.position).normalized;
        float angle = Vector3.Angle(direction, player.forward);

        if (angle < 30f)
        {
            RaycastHit hit;
            if (
                Physics.Raycast(
                    player.position,
                    direction,
                    out hit,
                    interactDistance,
                    interactLayer
                )
            )
            {
                if (hit.transform == transform)
                {
                    interactText.gameObject.SetActive(true);
                    playerInRange = true;
                }
                else
                {
                    interactText.gameObject.SetActive(false);
                    playerInRange = false;
                }
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
            playerInRange = false;
        }
    }

    IEnumerator FadeToBlack()
    {
        fadePanel.SetActive(true);
        float currentTime = 0f;
        CanvasGroup canvasGroup = fadePanel.GetComponent<CanvasGroup>();
        float originalAlpha = canvasGroup.alpha;
        float fadedAlpha = 1f;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(originalAlpha, fadedAlpha, currentTime / fadeDuration);
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
}
}
