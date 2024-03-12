using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class InteractableUIManager : MonoBehaviour
{
    InteractableObject interactableObject;

    PlayerInput playerInput;

    public Image SpinIcon;

    float start;
    float duration;

    private void Awake()
    {
        interactableObject = GetComponentInParent<InteractableObject>();
        
        playerInput = GameManager.Instance.Player.GetComponent<PlayerInput>();

        SpinIcon.gameObject.SetActive(false);

    }
    private void OnEnable()
    {
        start = 0;
        duration = 0;
        playerInput.onControlsChanged += OnControlsChanged;
        SetUIControlText();
    }
    private void OnDisable()
    {
        playerInput.onControlsChanged -= OnControlsChanged;
    }

    void OnControlsChanged(PlayerInput input)
    {
        SetUIControlText();
    }

    void SetUIControlText()
    {
        TextMeshProUGUI InteractText = GetComponentInChildren<TextMeshProUGUI>();

        InputAction InteractAction = playerInput.currentActionMap.FindAction("InteractPress");
        
        InteractText.text = InteractAction.GetBindingDisplayString(InputBinding.MaskByGroup(playerInput.currentControlScheme));
    }

    public void ShowHoldIndicator(float startTime,float holdDuration)
    {
       SpinIcon.gameObject.SetActive(true);

       start = startTime;
       duration = holdDuration;
    }

    public void HideHoldIndicator()
    {
        SpinIcon.gameObject.SetActive(false);

        start = 0;
        duration = 0;
    }

    private void Update()
    {
        if (SpinIcon.isActiveAndEnabled)
        {
            SpinIcon.fillAmount = Time.time - start / duration ;
            Debug.Log(Time.time - start / duration);
        }
    }
}
