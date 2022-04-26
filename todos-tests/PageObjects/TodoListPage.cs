using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using todos.tests.Drivers;

namespace todos.tests.PageObjects
{
    public class TodoListPage : BrowserInitialization
    {
        #region Elements
        public IWebElement SearchField => DriverContext.Driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input"));

        public IWebElement ToggleAll => DriverContext.Driver.FindElement(By.XPath("/html/body/ng-view/section/section/label"));

        public IWebElement CompleteButton =>
            DriverContext.Driver.FindElement(By.XPath("/html/body/ng-view/section/section/ul/li[1]/div/input"));

        public IList<IWebElement> TodoList =>
            DriverContext.Driver.FindElements(By.XPath("/html/body/ng-view/section/section/ul/li"));

        public IWebElement AllTaskList =>
            DriverContext.Driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[1]/a"));

        public IWebElement ActiveTaskList =>
            DriverContext.Driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[2]/a"));

        public IWebElement CompletedTaskList =>
            DriverContext.Driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[3]/a"));
        #endregion

        #region Methods
        public void AddAnItemToTodoList(string item)
        {
            SearchField.Click();
            SearchField.Clear();
            SearchField.SendKeys(item);
            SearchField.SendKeys(Keys.Enter);
            ActiveTaskList.Click();
        }

        public void CompleteATask(string item)
        {
            ActiveTaskList.Click();
            if (!GetTodoList().Any(list => list.Equals(item))) return;
            CompleteButton.Click();
            Thread.Sleep(2000);
            CompletedTaskList.Click();
        }

        public List<string> GetTodoList()
        {
            //ToggleAll.Click();
            var textList = TodoList.Select(el => el.Text).ToList();
            return textList;

        }

        public bool CheckIfATaskIsActive(string item)
        {
            var taskList = GetTodoList();
            return taskList.Contains(item);
        }

        public int CountTaskByState(string state)
        {
            if (state == "All")
            {
                AllTaskList.Click();
                return GetTodoList().Count;
            }
                
            if (state == "Active")
            {
                ActiveTaskList.Click();
                return GetTodoList().Count;
            }

            if (state == "Complete")
            { 
                CompletedTaskList.Click();
                return GetTodoList().Count;
            }

            return 0;
        }
        #endregion

    }
}