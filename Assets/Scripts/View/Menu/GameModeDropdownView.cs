using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay;
using TMPro;
using UnityEngine;

namespace View.Menu
{
  public class GameModeDropdownView : ViewBase
  {
    [Serializable]
    private struct GameModeWithText
    {
      public EGameMode gameMode;
      public string text;
    }

    [SerializeField]
    private TMP_Dropdown gameModeDropdown;

    [SerializeField]
    private List<GameModeWithText> gameModes;

    private void Start()
    {
      gameModeDropdown.options.Clear();
      foreach (GameModeWithText gameModeWithText in gameModes)
        gameModeDropdown.options.Add(new TMP_Dropdown.OptionData(gameModeWithText.text));
    }

    public EGameMode GetCurrentValue()
    {
      string selectedText = gameModeDropdown.options[gameModeDropdown.value].text;
      return gameModes.First(modeWithText => modeWithText.text == selectedText).gameMode;
    }
  }
}