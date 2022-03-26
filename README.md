# CS 458/858 Winter 2022: Team Immersion

Our study is focused on benchmarking several different sensori-motor contingencies, as described by [Mel Slater](https://doi.org/10.1098/rstb.2009.0138).

We've compiled an MVP of some of the scenes we developed/tested in our study, which you can download and run on an Oculus Quest HMD.

---
### What you'll need

- Oculus Developer account
- Oculus HMD ([dev mode](https://www.youtube.com/watch?v=jB1gwgSpU3E)) + controllers
- A computer with either Unity or SideQuest installed

> This project may work on other devices, with the appropriate setup.

## Running in Unity
Clone the repository using:
```
git clone https://github.com/typeou
```
–or download the project as a `.zip` and extract it.
<br /><br />

In Unity Hub, select the dropdown next to open, and select `Add project from disk`.

![how to add the project to Unity Hub](./img/unity-open.png)

Open the project using Unity version 2020.3.28f1. Open `File -> Build Settings`.

> You can click `Player Settings`, and check `XR Plug-in Management`, and make sure that `Oculus` (or whichever platform you're using) is checked.
> Also, make sure that your desired platform (Android, in this case) is set in the Build Settings window.

Make sure your Headset is connected (you should see it under `Run Device` in the Build Settings window. Hit `Build And Run`, and the project should start running on your HMD.

## Running via SideQuest

#### Prebuilt Binary
A prebuilt `.apk` file can be downloaded from the [Releases](https://github.com/typeou/458/releases) section.

---

#### Building From Source
Follow the [steps for Running in Unity](#running-in-unity). Instead of clicking `Build And Run`, hit `Build`, and save the `.apk` onto your computer. Proceed to the next steps.

---

### Uploading Via SideQuest
Launch SideQuest and make sure that your Quest HMD is detected. On the top right, click the `Install APK file from folder on computer` button, and upload the aforementioned `.apk` file.

![where to upload .apk in SideQuest](./img/sidequest.png)

To run the project, equip your headset, open the Apps icon. In the upper right, select the dropdown that says `All(X)`. Then, select `Unknown Sources`. From there, select the uploaded `.apk` file.

![where to launch the project from in the Quest](./img/quest-unknown-sources.png)
