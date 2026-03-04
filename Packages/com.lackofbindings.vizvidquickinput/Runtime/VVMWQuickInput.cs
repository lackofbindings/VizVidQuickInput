
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using JLChnToZ.VRC.Foundation;
using JLChnToZ.VRC.VVMW;
using UnityEngine.UI;
using VRC.SDK3.Components;

namespace Lackofbindings.World
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class VVMWQuickInput : UdonSharpBehaviour
    {
        [SerializeField, Locatable] Core core;
        [Locatable, BindUdonSharpEvent] public FrontendHandler handler;
        [Space(20)]

        [BindEvent(nameof(VRCUrlInputField.onEndEdit), nameof(_AddVideoDone))]
        public VRCUrlInputField  AddVideoInput;
        public byte videoPlayerIndex = 1;

        [BindEvent(nameof(VRCUrlInputField.onEndEdit), nameof(_AddImageDone))]
        public VRCUrlInputField AddImageInput;
        public byte imagePlayerIndex = 3;

        private VRCUrl blankUrl = new VRCUrl("");

        // [SerializeField, LocalizedLabel] Button urlInputConfirmButton;
        // [SerializeField, HideInInspector, Resolve(nameof(urlInputConfirmButton), NullOnly = false)] GameObject urlInputConfirmButtonObject;
        // [BindEvent(nameof(Button.onClick), nameof(_EnforceImmedPlayClick))]

        public GameObject disableUI;

        private void _AddUrl(VRCUrlInputField urlInputField, byte playerIndex)
        {
            VRCUrl url = urlInputField.GetUrl();
            if (!VRCUrl.IsNullOrEmpty(url)) {
                // Needs to be called on handler and not on core, otherwise it will not queue.
                handler.PlayUrl(url, playerIndex);
                urlInputField.SetUrl(blankUrl);
            }
        }

        private void setUIEnabled(bool state)
        {
            // if(Utilities.IsValid(disableUI)) disableUI.SetActive(state);
            AddVideoInput.interactable = state;
            AddImageInput.interactable = state;
        }

        public void _AddVideoDone() => _AddUrl(AddVideoInput, videoPlayerIndex);
        
        public void _AddImageDone() => _AddUrl(AddImageInput, imagePlayerIndex);

        // Called by FrontendHandler
        public void _OnUIUpdate() {
            bool hasHandler = Utilities.IsValid(handler);
            bool unlocked = !hasHandler || !handler.Locked;

            setUIEnabled(unlocked && !core.IsLoading);
        }
    }
}
