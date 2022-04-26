using System;
using FluentAssertions;
using TechTalk.SpecFlow;
using todos.tests.Drivers;
using todos.tests.PageObjects;

namespace todos.tests.StepDefinitions
{
    [Binding]
    public class TrackTodoListSteps : BrowserInitialization
    {
        private readonly TodoListPage _tlPage = new TodoListPage();

        #region Given
        [Given(@"I have a web application '(.*)' to help me track the todo list")]
        public void GivenIHaveAWebApplicationToHelpMeTrackTheTodoList(string url)
        {
            NavigateToSite(url);
        }

        #endregion

        #region When
        [When(@"I add an (.*) to my todo list")]
        public void WhenIAddAnToMyTodoList(string item)
        {
            _tlPage.AddAnItemToTodoList(item);
        }

        [When(@"I mark an (.*) on my todo list as complete")]
        public void WhenIMarkAnOnMyTodoListAsComplete(string item)
        {
            //add a step here to check if task exists as I've noticed the task doesn't get saved if re-open the browser in incognito
            if (_tlPage.CheckIfATaskIsActive(item) == false)
            {
                WhenIAddAnToMyTodoList(item);
            }

            _tlPage.CompleteATask(item);
        }

        #endregion

        #region Then
        [Then(@"I should see the (.*) in my active todo list")]
        public void ThenIShouldSeeTheInMyActiveTodoList(string item)
        {
            var list = _tlPage.GetTodoList();
            list.Should().Contain(item);
        }


        [Then(@"I should be able to see it as active in the '(.*)' tasks list")]
        public void ThenIShouldBeAbleToSeeItAsActiveInTheTasksList(string state)
        {
            var count = _tlPage.CountTaskByState(state);
            count.Should().BeGreaterOrEqualTo(1);

            Console.WriteLine($"there are {count} task left in todo list");
        }

        [Then(@"I should see the (.*) in my complete list")]
        public void ThenIShouldSeeTheInMyCompleteList(string item)
        {
            var list = _tlPage.GetTodoList();
            list.Should().Contain(item);
        }

        [Then(@"I should be able to see it as complete in the '(.*)' tasks list")]
        public void ThenIShouldBeAbleToSeeItAsCompleteInTheTasksList(string state)
        {
            var count = _tlPage.CountTaskByState(state);
            count.Should().BeGreaterOrEqualTo(1);

            Console.WriteLine($"there are {count} more tasks complete in todo list");
        }

        #endregion
    }
}
