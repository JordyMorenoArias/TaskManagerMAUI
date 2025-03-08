using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerMAUI.Services
{
    /// <summary>
    /// Service responsible for managing authentication tokens using Secure Storage.
    /// </summary>
    class TokenService : ITokenService
    {
        private const string TokenKey = "authToken";

        /// <summary>
        /// Saves the authentication token asynchronously.
        /// </summary>
        /// <param name="token">The authentication token to be stored.</param>
        /// <returns>A completed task.</returns>
        public Task SaveTokenAsync(string token)
        {
            SecureStorage.SetAsync(TokenKey, token);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Retrieves the stored authentication token asynchronously.
        /// </summary>
        /// <returns>The authentication token if it exists; otherwise, null.</returns>
        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(TokenKey);
        }

        /// <summary>
        /// Removes the stored authentication token.
        /// </summary>
        /// <returns>A completed task.</returns>
        public Task RemoveTokenAsync()
        {
            SecureStorage.Remove(TokenKey);
            return Task.CompletedTask;
        }
    }

}
