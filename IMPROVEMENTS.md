# test-project

### Things should be improved in code
1. Web element locator - in the 'TodoListPage.cs', I've used Xpath a lot which is not ideal. Going forward we should avoid using Xpath with text and indexing where possible
2. Config test to be able to run in different environments, currently only run against one env
3. Make the test web app link as a variable, currently it's hard coded in feature file. Going forward, we may need to run test against different envs in pipeline, it can be configured as pipeline variables.
4. Add proper logs, in my test, I only add some console logs for local debug. A good logging mechanism will make debug easier.
5. Make the browser type as a variable, it will enable us to run test against different type of browser base on the config, can be a pipeline variable too.
6. Add some web driver wait methods and keep the test more resilient.
7. I only complete the first 2 tests, the rest should be completed if I have more time. The base test framework has setup, and the rests should be fairly easy.

### Things to raise to development team
1. Try to use IDs, names for web elements to make locators easy to write.
2. Improve the UX design and make the web app a bit more user friendly.