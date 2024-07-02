using Xunit;
using ContactsManager;
using System;
using System.Collections.Generic;
using System.IO;

namespace ContactsManagerTest
{
    public class ProgramTest
    {
        
        [Fact]
        public void AddContact_ReturnAddSuccessMessage_ContactAdded()
        {
            // Arrange
            string userName = "TestName";
            string userContactNumber = "078778800";

            // Act
            string result = Program.AddContact(userName, userContactNumber);

            // Assert
            Assert.Equal("Contact 'TestName' added successfully.", result);
        }

        // Test for deleting an existing contact
        [Fact]
        public void DeleteContact_ReturnDeleteSuccessMessage_ContactDeleted()
        {
            // Arrange
            string userName = "TestName";
            string userContactNumber = "078778800";
            Program.AddContact(userName, userContactNumber);

            // Act
            string result = Program.RemoveContact(userName);

            // Assert
            Assert.Equal("Contact 'TestName' removed successfully.", result);
        }

        // Test for adding a contact that already exists
       [Fact]
        public void AddContact_ReturnAlreadyExistsMessage_ErrorContact()
        {
            // Arrange
            string userName = "TestName";
            string userContactNumber = "078778800";
            Program.AddContact(userName, userContactNumber);

            // Act
            string result = Program.AddContact(userName, userContactNumber);

            // Assert
            Assert.Equal("Contact with name 'TestName' already exists.", result);
        }

        // Test for viewing all contacts
        [Fact]
        public void ViewAllContacts_ReturnListOfContacts_SearchContacts()
        {
            // Arrange
            string userName1 = "TestName1";
            string userContactNumber1 = "078778800";
            Program.AddContact(userName1, userContactNumber1);

            string userName2 = "TestName2";
            string userContactNumber2 = "078778811";
            Program.AddContact(userName2, userContactNumber2);

            // Act
            string consoleOutput = CaptureConsoleOutput(() =>
            {
                Program.ViewContacts();
            });

            // Assert
            Assert.Contains("TestName1", consoleOutput);
            Assert.Contains("078778800", consoleOutput);
            Assert.Contains("TestName2", consoleOutput);
            Assert.Contains("078778811", consoleOutput);
        }

        // Helper method to capture console output
        private string CaptureConsoleOutput(Action action)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                action.Invoke();
                return sw.ToString().Trim();
            }
        }
    }
}
