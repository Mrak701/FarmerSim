
using UnityEngine;

namespace FarmerSim.Player
{
    public class DefaultPlayerView : MonoBehaviour, IPlayerView
    {
        public IPlayerModel PlayerModel { get; set; }

        [SerializeField] private Animator playerAnimator;

        public void Initialize(IPlayerModel playerModel)
        {
            this.PlayerModel = playerModel;
            this.PlayerModel.OnPlayerChanged += this.OnPlayerChanged;
        }

        private void OnPlayerChanged()
        {
            UpdatePlayerAnimator();
        }

        private void UpdatePlayerAnimator()
        {
            IPlayerBehavior playerBehavior = PlayerModel.GetCurrentBehavior();

            bool behaviorIsRunning = playerBehavior is PlayerBehaviorRunning;
            bool behaviorIsWaking = playerBehavior is PlayerBehaviorWalking;
            bool behaviorIsCutting = playerBehavior is PlayerBehaviorCutting;

            playerAnimator.SetBool("IsRunning", behaviorIsRunning);
            playerAnimator.SetBool("IsWalking", behaviorIsWaking);
            playerAnimator.SetBool("IsCutting", behaviorIsCutting);
        }

        private void OnDestroy()
        {
            PlayerModel.OnPlayerChanged -= this.OnPlayerChanged;
        }
    }
}