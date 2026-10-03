using Ilumisoft.RadarSystem.UI;
using UnityEngine;

namespace Ilumisoft.RadarSystem
{
    [AddComponentMenu("Radar System/Locatable")]

    public enum RadarVisibility
    {
        AlwaysVisible,
        ScanOnly
    }
    public class Locatable : LocatableComponent
    {
        [SerializeField]
        private RadarVisibility radarVisibility = RadarVisibility.ScanOnly;

        public RadarVisibility Visibility => radarVisibility;
        [SerializeField]
        protected LocatableIconComponent iconPrefab;

        [SerializeField, Tooltip("Determines whether the locatable will be hidden or will stay visible when being out of the radar radius")]
        private bool clampOnRadar = false;

        public override bool ClampOnRadar { get => clampOnRadar; set => clampOnRadar = value; }

        public override LocatableIconComponent CreateIcon()
        {
            return Instantiate(iconPrefab);
        }
    }
}