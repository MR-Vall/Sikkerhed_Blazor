using BlazorApp1.Components.Pages;
using Bunit;
using Bunit.TestDoubles;
using Xunit;

namespace BlazorAppTest
{
    public class UnitTest1
    {
        [Fact]
        public void Home_ShowsNotAuthenticatedMessage_WhenUserIsNotAuthenticated()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();

            // Act
            var cut = ctx.RenderComponent<Home>();

            // Assert
            cut.MarkupMatches("<h1>Hello, world!</h1>\r\nWelcome to your new app.\r\n<p>You are not an admin.</p>\r\n<p>You are not authenticated.</p>");
        }

        [Fact]
        public void Home_ShowsAuthenticatedMessage_WhenUserIsAuthenticated()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("testuser");

            // Act
            var cut = ctx.RenderComponent<Home>();

            // Assert
            cut.MarkupMatches("<h1>Hello, world!</h1>\r\nWelcome to your new app.\r\n<p>You are not an admin.</p>\r\n<p>You are authenticated.</p>");
        }

        [Fact]
        public void Home_ShowsAdminMessage_WhenUserIsAdmin()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("adminuser");
            authContext.SetRoles("Admin");

            // Act
            var cut = ctx.RenderComponent<Home>();

            // Assert
            cut.MarkupMatches("<h1>Hello, world!</h1>\r\nWelcome to your new app.\r\n<p>You are admin!</p>\r\n<p>You are authenticated.</p>");
        }

        [Fact]
        public void Home_ShowsNotAdminMessage_WhenUserIsNotAdmin()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("testuser");

            // Act
            var cut = ctx.RenderComponent<Home>();

            // Assert
            cut.MarkupMatches("<h1>Hello, world!</h1>\r\nWelcome to your new app.\r\n<p>You are not an admin.</p>\r\n<p>You are authenticated.</p>");
        }
    }
}

