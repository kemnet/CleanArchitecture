using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateUser()
        {
            var app = new Application.Application();
            
            var userName = "User1";
            var user = app.CreateUser(userName);

            Assert.Equal(userName, user.Name);
        }
        
        [Fact]
        public void CreateProject()
        {
            var app = new Application.Application();
            
            var userName = "User1";
            var projectName = "User1";
            var user = app.CreateUser(userName);
            
            var project = app.CreateProject(user, projectName);
            
            Assert.Equal(project.UserId,  user.Id);
            Assert.Equal(projectName,  project.Name);
        }
    }
}