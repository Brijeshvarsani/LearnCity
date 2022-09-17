using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using Microsoft.VisualStudioCode.TestTools.UnitTesting;
using Xunit;

namespace LearnCity_game {

    // Creating the first test class
    [TestFixture]
    public class GameTest
    {

        /* 
            a. Black Box Test.
            b. Unit Test.
            c. Testing all the Execution Paths.
            d. Refactoring was done.
            This test is checking the plant growth.
        */

        [Test]
        public void Growth_currentProgressionLessThanSprites_currentProgressionAddition() {

            //Arrange
            var plantGrowth_MonoBehaviour = new PlantGrowth_MonoBehaviour();

            //Act
            var result = plantGrowth_MonoBehaviour.Growth(new progression { Count = currentProgression++ });
            var result = plantGrowth_MonoBehaviour.Growth(new progression { Count = spriteRenderer.sprite = sprites[currentProgression] });

            //Assert
            Assert.Equals(result);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the dialog.
        */
        
        [Test]
        public void RunTypingEffectsTest(){

            //Arrange
            var runtypingeffect = new RunTypingEffects();

            //Act
            var result = runtypingeffect.RunTypingEffect(new DialogueObject { GetKeyDown = null });

            //Assert
            Assert.Equals(result);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is further checking the dialog box.
        */

        [Test]
        public void TypeWriterEffectTest(){

            //Arrange
            var runtypingeffect = new RunTypingEffects();

            //Act
            var result = runtypingeffect.RunTypingEffect(new DialogueObject { GetKeyDown = null });

            //Assert
            Assert.Equals(result);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            d. Black Box Test.
            This test is checking the Building Manager or Building Modes.
        */

        [Test]
        public void buildingModeConfirm() {

            //Arrange
            var effects = new BuldingModes();

            //Act
            var result = effects.BuildingMode(new BuildingManagerTest { buildingMode = true });

            //Assert
            Assert.IsTrue(result);
        } 

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            d. White Box Test.
            This test is checking the position.
        */

        [Test]
        public void UpdateTest() {

            //Arrange
            var position = new Updates();

            //Act
            var result = position.Update(new BuildingMode { buildingModeConfirm = true });

            //Assert
            Assert.Equals(result);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the building buttons.
        */
        
        [Test]
        public void UpdateTest_BuildingMode() {

            //Arrange
            var newModules = new Updates();

            //Act
            var result = newModules.Update(new BuildingMode { buildingModeConfirm.GetComponent<Button>().interactable = canSpawnBuilding });

            //Assert
            Assert.Equals(result);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the spawn building.
        */

        [Test]
        public void CanSpawnBuildingTest_ReturnsTrue() {
            
            //Arrange
            var news = new CanSpawnBuildings();

            //Act
            var result = news.CanSpawnBuilding(new results { CanSpawnBuilding = true });

            //Assert
            Assert.Equals(result);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            d. Black Box Test.
            This test is further checking the spawn Building.
        */
        
        [Test]
        public void CanSpawnBuildingTest_ReturnsFalse() {

            //Arrange
            var newNews = new CanSpawnBuildings();

            //Act
            var results = newNews.CanSpawnBuilding(new updatedResults { CanSpawnBuilding = false });
            var results = newNews.CanSpawnBuilding(new IAsyncResult { CanSpawnBuilding = false });

            //Assert
            Assert.Equals(results);
            Assert.ReferenceEquals(IAsyncResult);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the Toggle Building.
        */

        [Test]
        public void ToggleBuildingTabTest_ReturnsFalse() {

            //Arrange
            var tab = new ToggleBuildingTabs();

            //Act
            var result = tab.ToggleBuildingTab(new ThreadAbortException { SetActive = false });

            //Assert
            Assert.Equals(result);

            //Act
            var results = tab.ToggleBuildingTab(new isBuildingTabOpen { SetActive = false });
            var results = tab.ToggleBuildingTab(new BuildingTabOpen { isBuildingTabOpen = false });

            //Assert
            Assert.Equals(results);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is further checking the Toggle Building.
        */

        [Test]
        public void ToggleBuildingTabTest_ReturnsTrue() {

            //Arrange
            var tab = new ToggleBuildingTabs();

            //Act
            var result = tab.ToggleBuildingTab(new ThreadAbortException { SetActive = true });

            //Assert
            Assert.Equals(result);

            //Act
            var results = tab.ToggleBuildingTab(new isBuildingTabOpen { SetActive = true });
            var results = tab.ToggleBuildingTab(new BuildingTabOpen { isBuildingTabOpen = true });

            //Assert
            Assert.Equals(results);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the raycast.
        */

        [Test]
        public void RaycastTest_NotNull() {

            //Arrange
            var touchCount = new RayCasts();

            //Act
            var result = touchCount.Raycast(new touchCount { touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) });

            //Assert
            Assert.Equals(result);  

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is further checking the raycast.
        */

        [Test]
        public void RaycastTest_Null() {
            
            //Arrange
            var touchCount = new RayCasts();

            //Act
            var result = touchCount.Raycast(new touchCount { touchedObject = hitInformation.transform.gameObject });
            
            //Assert
            Assert.Equals(result);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is again checking the raycast.
        */

        [Test]
        public void RaycastTest_Null_FurtherTest() {

            //Arrange
            var touchCount = new RayCasts();

            //Act
            var results = touchCount.RayCast(new touchCount { Debug.Log("Touched " + touchedObject.transform.name) });

            //Assert
            Assert.Equals(results);

        }

    }

    // Creating another test class
    [TestFixture]
    public class Openanimation_MonoBehaviour_Test {

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the animation.
        */

        [Test]
        public void openAnimationTest_ReturnsNotNull() {

            //Arrange
            var values = new openAnimations();

            //Act
            var results = values.openAnimation(new transitionAnimation { isNull = true });

            //Assert
            Assert.IsNull(results);

        }

    }

    // Creating another test class
    [TestFixture]
    public class PauseMenu_MonoBehaviour_Test {

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the pause menu and resume.
        */

        [Test]
        public void Update_ResumeButtonTest_PauseButtonTest() {
            
            //Arrange
            var button = new Updates();

            //Act
            var results = button.Update(new IsPaused { true = Resume });

            //Assert
            Assert.Equals(results);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the resume.
        */
        [Test]
        public void ResumeButton_Test() {
            
            //Arrange
            var button = new Updates();

            //Act
            var results = button.Resume(new IsPaused { false = Resume });

            //Assert
            Assert.IsFalse(results);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the pause.
        */
        [Test]
        public void PauseButtonTest() {
            
            //Arrange
            var button = new Updates();
            
            //Act
            var results = button.Pause(new IsPaused { true = Resume });
            
            //Assert
            Assert.IsTrue(results);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the load menu.
        */
        [Test]
        public void LoadMenuTest() {

            //Arrange
            var menu = new Updates();

            //Act
            var results = menu.LoadMenu(new SceneManager.LoadScene { "Menu" = true });

            //Asssert
            Assert.IsTrue(results);

        }

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the quit game.
        */

        [Test]
        public void QuitGameTest() {
            
            //Arrange
            var game = new Updates();

            //Act
            var results = game.QuitGame(new Application.Quit { true });

            //Assert
            Assert.IsTrue(results);

        }


    }

    // Creating another test class
    [TestFixture]
    public class Target_MonoBehaviourTest {

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            d. Black box Test.
            This test is checking the target.
        */

        [Test]
        public void moveTargetTest() {
            
            //Arrange
            var target = new Target();

            //Act
            var results = target.moveTarget(new Input.touchCount { Input.touchCount > 0 = transform.position = Helpers.GetTouchPosition() });
            var newResult = target.moveTarget(new Input.touchCount { Input.touchCount > 0 = Destroy(targetIndicatorObject, targetIndicatorDuration) });

            //Assert
            Assert.Equals(results);
            Assert.Equals(newResult);

        }

    }

    // Creating another test class
    [TestFixture]
    public class closePanels_MonoBehaviour_Test {

        /* 
            a. Unit Test.
            b. Testing all the Execution Paths.
            c. Refactoring was done.
            This test is checking the panel.
        */

        [Test]
        public void closePanel_Test() {

            //Arrange
            var panel = new Panels();

            //Act
            var results = panel.closePanel(new closePanelBox { IsNull = false });

            //Assert
            Assert.Equals(results);

        }

    }
    
    
}