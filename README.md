# Game Development in Progress
To be Continued...
## Rough Sketch of Game Style
- 2D game
- Story driven
- Top-down Straight

# Building This Project
Be sure you have the following applications installed on your machine:
- Unity
- GitHub Desktop
  
You may choose to:

- Fork this repo (on the top right of the screen) which will add a clone into your account, or
- Clone the repository directly from a version control program.

Forking the repository will simplify the process. Once you have forked this repo, simply open up
GitHub for Desktop, and click on the "+" symbol on the top left of the screen. Select "clone" and
then your forked repository. Once you click on the checkmark, a clone of the repo will be successfully
added into your github directory.


# Obtain the Repository Without GUI
In this case, we assume you are using Git, be sure to locate your directory of choice, from which
to add this repository. Next, use the command:

```Bash
# Once you execute this command, you will be prompted for username and password.
git clone https://github.com/CheezBoiger/UnityGame-Temporary.git
```
From here the repository will be cloned into your directory of choice.

# Syncing Your work
To sync your project with this remote, use the following commands from your Git command terminal:
```Bash
# If you need to update anything from the repository
git remote add upstream https://github.com/CheezBoiger/UnityGame-Temporary.git
git fetch upstream
git checkout master
git merge upstream/master
```
Or, if you prefer the GUI way of doing things, you will be disheartened to know that the Github desktop will not be able to
sync your work into the repo directly, but do not freight. Simply push your changes into your forked repo, and submit
a pull request to our master remote. Any conflicts will be taken care of and so forth.

Finally, open up Unity, and select "Open", then locate the folder in which the project is located in (be sure to select "Game-Src" as the
folder to open). The project will be set up for you. Next, select on the top left tabs Edit->Project Settings->Editor. On the right of the screen, you will see Editor Settings, select Mode under Version Control and set it to "Visible Meta Files", then select Mode for Asset Serialization and set it to "Force Text". Any updates you obtain from our repository should be automatically synced to the unity project on start up.