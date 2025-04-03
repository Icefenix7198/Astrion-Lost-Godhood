
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
        [Tooltip("Reference to the GameObject that has the karmaManager")]
        [SerializeField] protected GameObject karmaManager;

        [Tooltip("Name of the method to call")]
        [SerializeField] protected int karma = 0;

      
        #region Public members

        public override void OnEnter()
        {
            //if (karmaManager != null)
            //{
            //    karmaManager;
            //    return;
            //}
        }
    
        #endregion
    }
}