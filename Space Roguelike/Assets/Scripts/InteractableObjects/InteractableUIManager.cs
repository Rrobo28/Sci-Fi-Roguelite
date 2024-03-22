
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class InteractableUIManager : MonoBehaviour
{
    public InteractableObject interactableObject;

    PlayerInput playerInput;

    public Image SpinIcon;
   
    private void Start()
    {
        SpinIcon.gameObject.SetActive(false);

        playerInput = GameManager.Player.GetComponent<PlayerInput>();

        
    }
    private void OnEnable()
    {
        if(playerInput)
        {
            playerInput.onControlsChanged += OnControlsChanged;
            SetUIControlText();
        }
       
    }
    private void OnDisable()
    {
        if (playerInput)
        {
            playerInput.onControlsChanged -= OnControlsChanged;
        }
    }

    void OnControlsChanged(PlayerInput input)
    {
        SetUIControlText();
    }

    void SetUIControlText()
    {
         TextMeshProUGUI InteractText = GetComponentInChildren<TextMeshProUGUI>();

        InputAction InteractAction = playerInput.currentActionMap.FindAction("InteractPress");

        InteractText.text = InteractAction.GetBindingDisplayString(InputBinding.MaskByGroup(playerInput.currentControlScheme)) + " To Interact";
    }

    public void ShowHoldIndicator()
    {
        SpinIcon.gameObject.SetActive(true);
    }

    public void HideHoldIndicator()
    {
        SpinIcon.gameObject.SetActive(false);
    }

    public void ShowInteractUI()
    {
        if (interactableObject.hasHighlight && interactableObject.Highlight)
        {
            interactableObject.Highlight.enabled = true;
        }
    }
    public void HideInteractUI()
    {
        if (interactableObject.hasHighlight && interactableObject.Highlight)
        {
            interactableObject.Highlight.enabled = false;
        }

    }

    private void Update()
    {
        if (SpinIcon.gameObject.activeInHierarchy)
        {
            SpinIcon.fillAmount = Time.time - interactableObject.HoldStartTime / interactableObject.HoldDuration;
        }
    }
}
