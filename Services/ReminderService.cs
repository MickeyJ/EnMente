using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnMente.Models;
using SQLite;

namespace EnMente.Services
{
    public class ReminderService : IReminderService
    {
        private const string DB_NAME = "enmente.db3";
        private SQLiteAsyncConnection _connection;

        public ReminderService()
        {
            // _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            // _connection.CreateTableAsync<ReminderModel>().Wait();

            SetUpDb();
        }

        private async void SetUpDb()
        {
            try
            {
                if (_connection == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME);
                    _connection = new SQLiteAsyncConnection(dbPath);
                    await _connection.CreateTableAsync<ReminderModel>();
                }
            }
            catch (Exception e)
            {

            }

        }

        public async Task<List<ReminderModel>> GetAllReminders()
        {
            return await _connection.Table<ReminderModel>().ToListAsync();
        }

        public async Task<ReminderModel> GetReminderById(int id)
        {
            return await _connection.Table<ReminderModel>().Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveReminder(ReminderModel reminder)
        {
            if (reminder.Id != 0)
            {
                return await _connection.UpdateAsync(reminder);
            }
            else
            {
                return await _connection.InsertAsync(reminder);
            }
        }

        public async Task<int> DeleteReminder(ReminderModel reminder)
        {
            return await _connection.DeleteAsync(reminder);
        }
    }
}
