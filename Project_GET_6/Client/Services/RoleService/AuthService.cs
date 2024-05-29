namespace Project_GET_6.Client.Services.RoleService
{
    public class AuthService
    {
        public string CurrentRoleName { get; private set; }

        public void SetCurrentRoleName(string name)
        {
            if (!string.Equals(CurrentRoleName, name))
            {
				CurrentRoleName = name;
                NotifyStateChanged();
            }
        }

        public event Action OnChange; // event raised when changed

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
