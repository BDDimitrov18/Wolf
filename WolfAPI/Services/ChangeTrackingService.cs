using WolfAPI.Models;

namespace WolfAPI.Services
{
    public class ChangeTrackingService
    {
        private readonly Dictionary<string, Stack<Change>> _userChangeHistories = new Dictionary<string, Stack<Change>>();

        public void AddChangeForUser(string userId, Change change)
        {
            if (!_userChangeHistories.ContainsKey(userId))
            {
                _userChangeHistories[userId] = new Stack<Change>();
            }
            _userChangeHistories[userId].Push(change);
        }

        public Change UndoLastChangeForUser(string userId)
        {
            if (_userChangeHistories.ContainsKey(userId) && _userChangeHistories[userId].Count > 0)
            {
                return _userChangeHistories[userId].Pop();
            }
            return null;
        }

        public void StartUserSession(string userId)
        {
            if (!_userChangeHistories.ContainsKey(userId))
            {
                _userChangeHistories[userId] = new Stack<Change>();
            }
        }

        public void EndUserSession(string userId)
        {
            if (_userChangeHistories.ContainsKey(userId))
            {
                _userChangeHistories.Remove(userId);
            }
        }
    }

}
