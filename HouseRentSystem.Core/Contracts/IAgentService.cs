namespace HouseRentSystem.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsByIdAsync(string agentId);

        Task<bool> UserWithPhoneNumberExixtsAsync(string phoneNumber);

        Task<bool> UserHasRentsAsync(string userId);

        Task CreateAsync(string userId, string phoneNumber);

        Task<int?> GetAgentIdAsync(string UserId);
    }
}
