# AllScenesWithSwitches

Unity/Quest application used to run the user study for **"Fidget Cubes as an input device in AR"**, a group project at TU Darmstadt.

The app presents a participant with a fixed sequence of AR scenes: an introduction, four interaction tasks (colour selection, menu navigation, object rotation, object sorting), short instruction screens between them, and a closing screen. The experimenter advances the sequence manually by pressing **Space** on a Bluetooth keyboard paired with the headset.

The fidget cube itself was **not** connected to the headset. It was a plain physical cube held by the participant; the app only displayed the scene they were asked to solve, while the participant described and demonstrated how they *would* use the cube. This is why the project is a scene player and contains no cube input handling.

## Requirements

- Unity **2022.3.27f1**
- Meta Quest 2 or Quest 3, in developer mode
- A Bluetooth keyboard paired with the headset (used only to advance scenes)

The Oculus Integration SDK is vendored under `Assets/Oculus`, so no separate SDK import is needed. Only the `VR` and `Spatializer` modules are kept — the unused ones (SampleFramework, LipSync, Interaction, Voice, Platform, AudioManager) were removed to keep the repository a reasonable size.

## Running it

1. Open the project in Unity 2022.3.27f1.
2. Switch the build target to **Android**.
3. Build and deploy to the headset, or use Quest Link and press Play in the Editor.
4. Press **Space** to advance to the next scene. There is no back navigation and no other input.

## Scene flow

Scenes advance linearly on each Space press. The order in `EditorBuildSettings` is not the play order — scenes are loaded by name.

| # | Scene | Purpose | Advance script |
|---|-------|---------|----------------|
| 1 | `NewStart` | Welcome and introduction text | `FirstSkip.cs` |
| 2 | `SelectionColor` | Selection task: pick the odd-coloured object | `Skip1.cs` |
| 3 | `NewMiddle1` | Instruction screen | `mid1.cs` |
| 4 | `SelectionMenu` | Menu navigation task | `Skip2.cs` |
| 5 | `NewMiddle2` | Instruction screen | `macaron.cs` |
| 6 | `RotationScene` | Manipulation task: rotate the cube | `Skip3.cs` |
| 7 | `NewMiddle3` | Instruction screen | `mid3.cs` |
| 8 | `MoveObjectScene` | Manipulation task: sort objects by colour | `LastSkip.cs` |
| 9 | `NewEnd` | Closing screen | — |

Each advance script is a `MonoBehaviour` on a scene object whose only job is
`if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("<next>")`.

## Layout

```
Assets/
  Scenes/        the nine study scenes
  *.cs           scene-advance scripts and two shared behaviours
  scripts/
    Selection_ColorSwitch/   colour-selection task
    Selection_Menu/          menu-navigation task
    MoveObject/              object-sorting task
  Oculus/        vendored Oculus Integration SDK, VR + Spatializer only
  TextMesh Pro/  text rendering
ProjectSettings/ build scene list and XR settings
```

The task behaviours:

- `scripts/Selection_ColorSwitch/Change Color.cs`, `bannerBehaviour.cs` — drive the colour-selection scene and its instruction banner.
- `scripts/Selection_Menu/ChangeMode.cs`, `cubeChangeWithMenu.cs`, `sphereBehaviour.cs`, `banner_Menu.cs` — the menu scene, where the cube is swapped for a sphere through menu settings.
- `scripts/MoveObject/OrderObjects.cs`, `TextObject.cs` — animate a set of coloured objects being sorted, with configurable delays.
- `brev.cs` (`CubeRotator`) — rotates a cube through a fixed pattern after a 6 s delay; used in the rotation and sorting scenes.
- `HideText.cs` — hides the instruction text after a delay and reveals the task objects.


## Paper

*Fidget Cubes as an input device in AR.* TU Darmstadt.

The study used a within-subjects elicitation design with 12 participants across the four task scenes above, in both AR and VR conditions. Participants largely fell back on familiar interaction patterns — the joystick as a game controller, the rolling ball as a mouse — and the cube's many input modalities produced a pronounced gulf of execution. Findings and limitations are in the paper.

## Licence

The project's own code and scenes are MIT licensed — see [LICENSE](LICENSE).

`Assets/Oculus` is the Oculus Integration SDK, Copyright © Meta Platforms, Inc., licensed under the [Oculus SDK License Agreement](https://developer.oculus.com/licenses/oculussdk/) and not covered by this repository's licence.
