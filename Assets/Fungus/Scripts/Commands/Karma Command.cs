
using UnityEngine;


namespace Fungus
{
    /// <summary>
    /// Modify Player's karma.
    /// </summary>

    [CommandInfo("Narrative",
                 "Karma",
                 "Modify Player's karma")]

    public class Karma : Command
    {
        [Tooltip("Name of the method to call")]
        [SerializeField] protected int karmaModification = 0;

      
        #region Public members

        public override void OnEnter()
        {
            if (KarmaManager.Instance != null)
            {
                KarmaManager.Instance.ModifyKarma(karmaModification, GetFlowchart());

                Continue(); // Move to the next Fungus command
            }
            else
            {
                Debug.LogError("KarmaManager instance not found");
            }
        }
    
        #endregion
    }
}