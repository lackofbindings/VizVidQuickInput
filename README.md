# VizVid Quick Input

<image src="docs/resources/preview.jpg" width="512" />

An unofficial add-on for the VRChat VizVid video player system that adds large simple-to-use buttons to quickly add URLs with no fuss. It interacts with the `PlayUrl()` method exposed by VizVid's `FrontendHandler`.

This skips over the fiddly UX of having to click the bar, enter a url, choose a player from the tiny dropdown, and finally click the tiny enqueue button. This prefab replaces all of that with a single click, enter URL, done.

## Setup

### Dependencies

- Unity 2022.3.22f1 (or latest supported version).
- VRC SDK 3.x.x (Tested against 3.10.1 but should work in any version compatible with VizVid).
- [VizVid](https://github.com/JLChnToZ/VVMW) (Tested Against 1.4.12 but should work back to 1.2.0)

### Install

1. Go to the [VPM Listing](https://lackofbindings.github.io/VizVidQuickInput/) for this repo and hit "Add to VCC".
   
   - If the "Add to VCC" button does not work you can manually enter the following url into the Packages settings page of the VCC `https://lackofbindings.github.io/VizVidQuickInput/index.json` 

   - If you do not have access to the VCC, there are also unitypackage versions available in the [Releases](https://github.com/lackofbindings/VizVidQuickInput/releases/latest).

2. Once you have the repo added to your VCC, you can add VizVid Quick Input to your project from the Mange Project screen.

### Setup

1. Ensure that [VizVid](https://github.com/JLChnToZ/VVMW) is set up and working in your project before proceeding.

2. Drag the `VizVid Quick Input` prefab into your scene.

   - You can put it anywhere you want.

3. Fill out the `Core` and `FrontendHandler` fields on the udon behavior by dragging in the one from your VizVid instance or by clicking the `Auto Find` button.

4. Fill out the `videoPlayerIndex` and `imagePlayerIndex` field with the index of the handlers you want it to use for each button. The index depends on the order of the **Player Handlers** you have configured in your in your VizVid core. The first handler in the list is index 1.

## Usage

- Clicking one of the buttons should open the VRChat URL input modal.
- Once the user enters a URL it will be queued to be played via the configured handler for that button.
