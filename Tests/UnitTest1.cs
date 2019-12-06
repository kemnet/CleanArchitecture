using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateUser()
        {
            var app = new Application.Application();
            
            var userId = Guid.NewGuid();
            var userName = "User1";
            
            app.CreateUser(userId, userName);
            var user = app.GetUser(userId);
            Assert.Equal(userName, user.Name);
        }
        
        [Fact]
        public void CreateProject()
        {
            var app = new Application.Application();
            
            var userId = Guid.NewGuid();
            var userName = "User1";
            
            //app.CreateUser(userId, userName);
            app.CreateProject(userId, "Project1");
        }
    }
}