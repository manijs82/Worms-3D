using System;
using TMPro;
using UnityEngine;

namespace Worms
{
    public class GameSettingsUi : MonoBehaviour
    {
        [SerializeField] private TeamSettings _teamSettings;
        [SerializeField] private TextMeshProUGUI _teamCountText;
        [SerializeField] private TextMeshProUGUI _playerPerTeamText;
        
        public void SetTeamCount(Single count)
        {
            _teamSettings.TeamCount = (int) count;
            _teamCountText.text = ((int)count).ToString();
        }
        
        public void SetPlayerPerTeamCount(Single count)
        {
            _teamSettings.PlayerPerTeam = (int) count;
            _playerPerTeamText.text = ((int)count).ToString();
        }
    }
}