using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Worms
{
    public class TeamStatPanel : MonoBehaviour
    {
        [SerializeField] private Image _backImage;
        [SerializeField] private TextMeshProUGUI _teamText;
        [SerializeField] private TextMeshProUGUI _statText;
        [SerializeField] private Color _highlightColor;
        [SerializeField] private Color _disableColor;
        [SerializeField] private Color _deadColor;
        
        [HideInInspector] public Team team;
        
        public void Initialize(Team team, int teamIndex)
        {
            this.team = team;
            
            _teamText.text = $"Team {teamIndex}";
            _statText.text = $"{team.PlayerCount}/{team.MaxPlayers}";
            team.OnPlayerDeath += UpdateStats;
            team.OnAllDeath += EnableDeadColor;
        }

        private void UpdateStats()
        {
            _statText.text = $"{team.PlayerCount}/{team.MaxPlayers}";
        }

        public void HighLightPanel(bool active)
        {
            _backImage.color = active ? _highlightColor : _disableColor;
        }

        private void EnableDeadColor()
        {
            _backImage.color = _deadColor;
        }
    }
}