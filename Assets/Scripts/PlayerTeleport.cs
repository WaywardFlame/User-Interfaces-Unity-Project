using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleport : MonoBehaviour
{

    [SerializeField] CharacterController player;
    [SerializeField] GameObject teleportingOverlayUI;
    [SerializeField] GameObject playerMovementOverlayUI;
    [SerializeField] GameObject UITutorialOverlayUI;
    [SerializeField] GameObject WeaponControlsOverlayUI;


    void Awake()
    {
        player = player.GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Quest Tutorial"))
        {
            teleportingOverlayUI.SetActive(true);
            Vector3 location = new Vector3(0f, 2f, -124.9f);
            StartCoroutine(Teleport(location));
        } 
        else if (other.gameObject.CompareTag("Weapon Controls Tutorial"))
        {
            teleportingOverlayUI.SetActive(true);
            Vector3 location = new Vector3(-114.3f, 2f, -124.9f);
            StartCoroutine(Teleport(location));
            StartCoroutine(SetWeaponControlsActiveOverlay());
            Debug.Log("Exit Tutorial");
        }
        else if (other.gameObject.CompareTag("Gathering Materials Tutorial"))
        {
            teleportingOverlayUI.SetActive(true);
            Vector3 location = new Vector3(-114.3f, 2f, 1f);
            StartCoroutine(Teleport(location));
            Debug.Log("Exit Tutorial");
        }
        else if (other.gameObject.CompareTag("UI Tutorial"))
        {
            teleportingOverlayUI.SetActive(true);
            Vector3 location = new Vector3(0f, 2f, 125f);
            StartCoroutine(Teleport(location));
            StartCoroutine(SetUITutorialActiveOverlay());
            Debug.Log("Exit Tutorial");
        }
        else if (other.gameObject.CompareTag("Movement Controls Tutorial"))
        {
            teleportingOverlayUI.SetActive(true);
            Vector3 location = new Vector3(-114.3f, 2f, 125f);
            StartCoroutine(Teleport(location));
            StartCoroutine(SetPlayerMovementActiveOverlay());
            Debug.Log("Exit Tutorial");
        }
        else if (other.gameObject.CompareTag("Exit Tutorial"))
        {
            teleportingOverlayUI.SetActive(true);
            Vector3 location = new Vector3(15.24f, 2f, -13.18f);
            StartCoroutine(Teleport(location));
            Debug.Log("Exit Tutorial");
        } 
        else if (other.gameObject.CompareTag("Exit Tutorial Scene"))
        {
            SceneManager.LoadScene(1);
        }
        else if (other.gameObject.CompareTag("Enter Tutorial Scene"))
        {
            SceneManager.LoadScene(2);
        }
        
    }

    IEnumerator Teleport(Vector3 location) 
    {
       Debug.Log("We Tp now!");
        yield return new WaitForSeconds(2);
        teleportingOverlayUI.SetActive(false);
        UITutorialOverlayUI.SetActive(false);
        playerMovementOverlayUI.SetActive(false);
        player.transform.position = location;
    }

    IEnumerator SetUITutorialActiveOverlay()
    {
        yield return new WaitForSeconds(2);
        UITutorialOverlayUI.SetActive(true);
    }
    
    IEnumerator SetPlayerMovementActiveOverlay()
    {
        yield return new WaitForSeconds(2);
        playerMovementOverlayUI.SetActive(true);
    }

    IEnumerator SetWeaponControlsActiveOverlay()
    {
        yield return new WaitForSeconds(2);
        WeaponControlsOverlayUI.SetActive(true);
    }
}
