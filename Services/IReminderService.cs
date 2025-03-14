using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnMente.Models;

namespace EnMente.Services
{
    internal interface IReminderService
    {
        Task<List<ReminderModel>> GetAllReminders();
        Task<ReminderModel> GetReminderById(int id);
        Task<int> SaveReminder(ReminderModel reminder);
        Task<int> DeleteReminder(ReminderModel reminder);
    }
}
