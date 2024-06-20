using System;
using UnityEngine;
using UnityEngine.UI;

namespace Desktop
{
    public class DesktopMenuAnimsManager : MonoBehaviour
    {
        [SerializeField] private AudioSource soundClick;
        [SerializeField] private DesktopMenu[] desktopMenuScreens;
        [SerializeField] private GameObject escMenu;
        [SerializeField] private Button[] escMenuButtons;
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");
        private bool isOpenEscMenu;
        private bool isAllMenuClose = true;

        private void Start()
        {
            foreach (var desktopMenuScreen in desktopMenuScreens)
            {
                desktopMenuScreen.MenuButton.onClick.AddListener(() => SwitchMenu(desktopMenuScreen));
            }
            foreach (var escMenuButton in escMenuButtons)
            {
                escMenuButton.onClick.AddListener(ButtonClick);
            }
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
                return;

            soundClick.Play();

            if (!isAllMenuClose)
                CloseAllMenuScreens();
            else
                OpenEscMenu();
        }

        private void SwitchMenu(DesktopMenu desktopMenuScreen)
        {
            CloseAllMenuScreens(desktopMenuScreen);
            desktopMenuScreen.MenuAnimator.SetBool(IsOpen, !desktopMenuScreen.IsMenuOpen);
            desktopMenuScreen.IsMenuOpen = !desktopMenuScreen.IsMenuOpen;
            isAllMenuClose = !desktopMenuScreen.IsMenuOpen;
        }

        private void CloseAllMenuScreens(DesktopMenu desktopMenu = null)
        {
            foreach (var desktopMenuScreen in desktopMenuScreens)
            {
                if (desktopMenuScreen == desktopMenu)
                    continue;

                desktopMenuScreen.MenuAnimator.SetBool(IsOpen, false);
                desktopMenuScreen.IsMenuOpen = false;
                isAllMenuClose = false;
            }
            isAllMenuClose = true;
        }

        private void OpenEscMenu()
        {
            escMenu.SetActive(!isOpenEscMenu);
            isOpenEscMenu = !isOpenEscMenu;
        }

        private void ButtonClick()
        {
            soundClick.Play();

            if (!isAllMenuClose)
                CloseAllMenuScreens();
            else
                OpenEscMenu();
        }

        private void OnDestroy()
        {
            foreach (var desktopMenuScreen in desktopMenuScreens)
            {
                desktopMenuScreen.MenuButton.onClick.RemoveAllListeners();
            }
            foreach (var escMenuButton in escMenuButtons)
            {
                escMenuButton.onClick.RemoveListener(ButtonClick);
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
}