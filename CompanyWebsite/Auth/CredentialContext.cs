using System;

namespace CompanyWebsite.Auth
{
    public class CredentialContext : ICredentialContext
    {
        public string Mailtrap_Username { get; set; } =
            Environment.GetEnvironmentVariable("Project_CompanyWebsite.Mailtrap_Username", EnvironmentVariableTarget.User);

        public string Mailtrap_Password { get; set; } =
            Environment.GetEnvironmentVariable("Project_CompanyWebsite.Mailtrap_Password", EnvironmentVariableTarget.User);
    }
}