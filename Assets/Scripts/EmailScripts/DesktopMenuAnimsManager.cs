using System;
using UnityEngine;
using UnityEngine.UI;

public class DesktopMenuAnimsManager : MonoBehaviour
{
    [SerializeField] private DesktopMenu[] desktopMenuScreens;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    private void Start()
    {
        foreach (var desktopMenuScreen in desktopMenuScreens)
        {
            desktopMenuScreen.MenuButton.onClick.AddListener(() => SwitchMenu(desktopMenuScreen));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseAllMenuScreens();
        }
    }

    private void SwitchMenu(DesktopMenu desktopMenuScreen)
    {
        CloseAllMenuScreens(desktopMenuScreen);
        desktopMenuScreen.MenuAnimator.SetBool(IsOpen, !desktopMenuScreen.IsMenuOpen);
        desktopMenuScreen.IsMenuOpen = !desktopMenuScreen.IsMenuOpen;
    }

    private void CloseAllMenuScreens(DesktopMenu desktopMenu = null)
    {
        foreach (var desktopMenuScreen in desktopMenuScreens)
        {
            if (desktopMenuScreen == desktopMenu)
                continue;

            desktopMenuScreen.MenuAnimator.SetBool(IsOpen, false);
            desktopMenuScreen.IsMenuOpen = false;
        }
    }

    private void OnDestroy()
    {
        foreach (var desktopMenuScreen in desktopMenuScreens)
        {
            desktopMenuScreen.MenuButton.onClick.RemoveAllListeners();
        }
    }

    [Serializable]
    private class DesktopMenu
    {
        [field: SerializeField] public Animator MenuAnimator { get; private set; }
        [field: SerializeField] public Button MenuButton { get; private set; }
        public bool IsMenuOpen { get; set; }
    }
}